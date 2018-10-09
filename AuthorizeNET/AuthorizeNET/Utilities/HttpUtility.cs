namespace AuthorizeNet.Utilities
{
	using Api.Contracts.V1;
	using Api.Controllers.Bases;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Net.Http;
	using System.Text;
	using System.Net;

	public static class HttpUtility
	{
        
		private static readonly ILogger Logger = LogFactory.getLog(typeof(HttpUtility));
		private static bool _proxySet;

		private static Uri GetPostUrl(AuthorizeNet.Environment env)
		{
			var postUrl = new Uri(env.XmlBaseUrl + "/xml/v1/request.api");
			Logger.LogDebug("Creating PostRequest Url: '{0}'", postUrl);

			return postUrl;
		}

		public static ANetApiResponse PostData<TQ, TS>(AuthorizeNet.Environment env, TQ request)
			where TQ : ANetApiRequest
			where TS : ANetApiResponse
		{
			ANetApiResponse response = null;
			if (null == request)
			{
				throw new ArgumentNullException("request");
			}
			Logger.LogDebug("MerchantInfo->LoginId/TransactionKey: '{0}':'{1}'->{2}", request.merchantAuthentication.name, request.merchantAuthentication.ItemElementName, request.merchantAuthentication.Item);

			var postUrl = GetPostUrl(env);
			
			string responseAsString = null;
			using (var clientHandler = new HttpClientHandler())
			{
				clientHandler.Proxy = SetProxyIfRequested(clientHandler.Proxy, env);
				using (var client = new HttpClient(clientHandler))
				{
					//set the http connection timeout 
					var httpConnectionTimeout = AuthorizeNet.Environment.getIntProperty(Constants.HttpConnectionTimeout);
					client.Timeout = TimeSpan.FromMilliseconds(httpConnectionTimeout != 0 ? httpConnectionTimeout : Constants.HttpConnectionDefaultTimeout);
					var content = new StringContent(XmlUtility.Serialize(request), Encoding.UTF8, "text/xml");
					var webResponse = client.PostAsync(postUrl, content).Result;
					Logger.LogDebug("Retrieving Response from Url: '{0}'", postUrl);

					// Get the response
					Logger.LogDebug("Received Response: '{0}'", webResponse);
					responseAsString = webResponse.Content.ReadAsStringAsync().Result;
					Logger.LogDebug("Response from Stream: '{0}'", responseAsString);

				}
			}
			if (null != responseAsString)
			{
				try
				{
					// try deserializing to the expected response type
					response = XmlUtility.Deserialize<TS>(responseAsString);
				}
				catch (Exception)
				{
					// probably a bad response, try if this is an error response
					response = XmlUtility.Deserialize<ANetApiResponse>(responseAsString);
				}

				//if error response
				if (response is ErrorResponse)
				{
					response = response as ErrorResponse;
				}
			}

			return response;
		}

		public static IWebProxy SetProxyIfRequested(IWebProxy proxy, AuthorizeNet.Environment env)
		{
			var newProxy = proxy as WebProxy;
			ICredentials credentials = null;

			if (env.HttpUseProxy)
			{
				var proxyUri = new Uri(string.Format("{0}://{1}:{2}", Constants.ProxyProtocol, env.HttpProxyHost, env.HttpProxyPort));
				if (!_proxySet)
				{
					Logger.LogInformation(string.Format("Setting up proxy to URL: '{0}'", proxyUri));
					_proxySet = true;
				}

				if (!string.IsNullOrEmpty(env.HttpsProxyUsername))
				{
					//Set credentials
					credentials = new NetworkCredential(env.HttpsProxyUsername, env.HttpsProxyPassword);
				}

				if (null == proxy || null == newProxy)
				{
					if (credentials == null)
					{
						newProxy = new WebProxy(proxyUri);
					}
					else
					{
						newProxy = new WebProxy(proxyUri, true, null, credentials);
					}
				}
			}
			return (newProxy ?? proxy);
		}
	}
}
