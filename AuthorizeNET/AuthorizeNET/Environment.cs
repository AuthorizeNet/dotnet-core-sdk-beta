namespace AuthorizeNet
{
	/*================================================================================
    * 
    * Determines the target environment to post API requests.
    *
    * SANDBOX should be used for testing. Transactions submitted to the sandbox 
    * will not result in an actual card payment. Instead, the sandbox simulates 
    * the response. Use the Testing Guide to generate specific gateway responses.
    *
    * PRODUCTION connects to the production gateway environment.
    *
    *===============================================================================*/
	public class Environment
	{
		public static readonly Environment SANDBOX = new Environment("https://test.authorize.net", "https://apitest.authorize.net", "https://test.authorize.net");
		public static readonly Environment PRODUCTION = new Environment("https://secure2.authorize.net", "https://api2.authorize.net", "https://cardpresent.authorize.net");
		public static readonly Environment LOCAL_VM = new Environment(null, null, null);
		public static readonly Environment HOSTED_VM = new Environment(null, null, null);
		public static Environment CUSTOM = new Environment(null, null, null);
		
		public bool HttpUseProxy { get; set; }
		public string HttpsProxyUsername { get; set; }
		public string HttpsProxyPassword { get; set; }
		public string HttpProxyHost { get; set; }
		public int HttpProxyPort { get; set; }
		

		private Environment(string baseUrl, string xmlBaseUrl, string cardPresentUrl)
		{
			BaseUrl = baseUrl;
			XmlBaseUrl = xmlBaseUrl;
			CardPresentUrl = cardPresentUrl;
		}

		/// <summary>
		/// Gets the base url
		/// </summary>
		public string BaseUrl { get; private set; }

		/// <summary>
		/// Gets the xml base url
		/// </summary>
		public string XmlBaseUrl { get; private set; }

		/// <summary>
		/// Gets the card present url
		/// </summary>
		public string CardPresentUrl { get; private set; }

		/// <summary>
		/// Create a custom environment with the specified base url
		/// </summary>
		/// <param name="baseUrl">Base url</param>
		/// <param name="xmlBaseUrl">Xml base url</param>
		/// <returns>The custom environment</returns>
		public static Environment createEnvironment(string baseUrl, string xmlBaseUrl)
		{

			return createEnvironment(baseUrl, xmlBaseUrl, null);
		}


		/// <summary>
		/// Create a custom environment with the specified base url
		/// </summary>
		/// <param name="baseUrl">Base url</param>
		/// <param name="xmlBaseUrl">Xml base url</param>
		/// <param name="cardPresentUrl">Card present url</param>
		/// <returns>The custom environment</returns>
		public static Environment createEnvironment(string baseUrl, string xmlBaseUrl, string cardPresentUrl)
		{
			var environment = CUSTOM;
			environment.BaseUrl = baseUrl;
			environment.XmlBaseUrl = xmlBaseUrl;
			environment.CardPresentUrl = cardPresentUrl;

			return environment;
		}

		/// <summary>
		/// Reads an integer value from the environment
		/// </summary>
		/// <param name="propertyName">Name of the int property to read</param>
		/// <returns>Integer property value</returns>
		public static int getIntProperty(string propertyName)
		{
			int value = 0;
			var stringValue = GetProperty(propertyName);
			if (!string.IsNullOrWhiteSpace(stringValue))
			{
				int.TryParse(stringValue.Trim(), out value);
			}

			return value;
		}

		/// <summary>
		/// Reads a boolean value from the environment
		/// </summary>
		/// <param name="propertyName">Name of the boolean property to read</param>
		/// <returns>Boolean property value</returns>
		public static bool getBooleanProperty(string propertyName)
		{
			var value = false;
			var stringValue = GetProperty(propertyName);
			if (!string.IsNullOrWhiteSpace(stringValue))
			{
				bool.TryParse(stringValue.Trim(), out value);
			}

			return value;
		}

		/// <summary>
		/// Reads the value from the environment 
		/// </summary>
		/// <param name="propertyName">Name of the property to read</param>
		/// <returns>String property value</returns>
		public static string GetProperty(string propertyName)
		{
			return System.Environment.GetEnvironmentVariable(propertyName);
		}
	}
}