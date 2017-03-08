using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;

namespace AuthorizeNET.Utilities
{
    public static class XmlUtility
    {

        private static readonly ILogger Logger = LogFactory.getLog(typeof(XmlUtility));

        public static string Serialize<T>(T entity) //where T: object //MarshalByRefObject //Serializable 
        {
            string xmlString;
            var requestType = typeof(T);

            try
            {
                var serializer = new XmlSerializer(requestType);
                var settings = new XmlWriterSettings() { Encoding = new UTF8Encoding() };
                using (var textWriter = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, entity);
                    }

                    xmlString = textWriter.ToString();
                }
            }
            catch (Exception e)
            {
                Logger.LogError("Error:'{0}' when serializing object:'{1}' to xml", e.Message, requestType);
                throw;
            }

            return xmlString;
        }

        public static T Deserialize<T>(string xml) //where T: object //MarshalByRefObject
        {
            var entity = default(T);

            if (!string.IsNullOrWhiteSpace(xml))
            {
                var responseType = typeof(T);
                try
                {
                    var serializer = new XmlSerializer(responseType);
                    using (var reader = new StringReader(xml))
                    {
                        entity = (T)serializer.Deserialize(reader);
                    }
                }
                catch (Exception e)
                {
                    Logger.LogError("Error:'{0}' when deserializing the into object:'{1}' from xml:'{2}'", e.Message, responseType, xml);
                    throw;
                }
            }

            return entity;
        }
    }
}
