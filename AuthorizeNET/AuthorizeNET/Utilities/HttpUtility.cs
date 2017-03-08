namespace AuthorizeNET.Utilities
{
    using System;
    using System.Text;
    using Api.Contracts.V1;
    using Api.Controllers.Bases;
    using Microsoft.Extensions.Logging;
    using System.Net.Http;

    public static class HttpUtility
    {

        //Max response size allowed: 64 MB
        private const int MaxResponseLength = 67108864;
        private static readonly ILogger Logger = LogFactory.getLog(typeof(HttpUtility));
        private static bool _proxySet;// = false;

        static readonly bool UseProxy = AuthorizeNET.Environment.getBooleanProperty(Constants.HttpsUseProxy);
        static readonly string ProxyHost = AuthorizeNET.Environment.GetProperty(Constants.HttpsProxyHost);
        static readonly int ProxyPort = AuthorizeNET.Environment.getIntProperty(Constants.HttpsProxyPort);

        private static Uri GetPostUrl(AuthorizeNET.Environment env)
        {
            var postUrl = new Uri(env.XmlBaseUrl + "/xml/v1/request.api");
            Logger.LogDebug("Creating PostRequest Url: '{0}'", postUrl);

            return postUrl;
        }

        public static ANetApiResponse PostData<TQ, TS>(AuthorizeNET.Environment env, TQ request)
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
            var requestType = typeof(TQ);
            string responseAsString = null;
            using (var clientHandler = new HttpClientHandler())
            {
                //TODO: clientHandler.Proxy = SetProxyIfRequested(clientHandler.Proxy);
                using (var client = new HttpClient(clientHandler))
                {
                    //set the http connection timeout 
                    var httpConnectionTimeout = AuthorizeNET.Environment.getIntProperty(Constants.HttpConnectionTimeout);
                    client.Timeout = TimeSpan.FromMilliseconds(httpConnectionTimeout != 0 ? httpConnectionTimeout : Constants.HttpConnectionDefaultTimeout);

                    //set the time out to read/write from stream
                    //var httpReadWriteTimeout = AuthorizeNET.Environment.getIntProperty(Constants.HttpReadWriteTimeout);
                    //client.ReadWriteTimeout = (httpReadWriteTimeout != 0 ? httpReadWriteTimeout : Constants.HttpReadWriteDefaultTimeout);

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
                
        //public static IWebProxy SetProxyIfRequested(IWebProxy proxy)
        //{
        //    var newProxy = proxy as WebProxy;

        //    if (UseProxy)
        //    {
        //        var proxyUri = new Uri(string.Format("{0}://{1}:{2}", Constants.ProxyProtocol, ProxyHost, ProxyPort));
        //        if (!_proxySet)
        //        {
        //            Logger.info(string.Format("Setting up proxy to URL: '{0}'", proxyUri));
        //            _proxySet = true;
        //        }
        //        if (null == proxy || null == newProxy)
        //        {
        //            newProxy = new WebProxy(proxyUri);
        //        }

        //        newProxy.UseDefaultCredentials = true;
        //        newProxy.BypassProxyOnLocal = true;
        //    }
        //    return (newProxy ?? proxy);
        //}
    }
}
