using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Xml;

namespace RestApi.Framework
{
    public static class SqlQueryStringReader
    {
        private const int maxRetryCount = 3;
        private const int retrySleepTimeMilliseconds = 3000;

        public static string GetSqlQuery(string id, string xmlFilename)
        {
            return ReadQueryStringFromFile(id, xmlFilename);
        }

        private static string ReadQueryStringFromFile(string id, string xmlFileName)
        {
            int retryCount = 0;
            try
            {
                var filePath = ConfigurationManager.AppSettings["XmlQueryPath"] + xmlFileName + ".xml";

                using(var reader =  new XmlTextReader(filePath))
                {
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    while (reader.Read())
                    {
                        if(reader.NodeType == XmlNodeType.Element && reader.Name == "SQLQueryString")
                        {
                            string currentId = reader.GetAttribute("Id");
                            if(currentId == id)
                            {
                                reader.Read();
                                return reader.Value;
                            }
                        }
                    }
                }
            }
            catch(IOException e)
            {
                if(++retryCount > maxRetryCount)
                {
                    throw;
                }

                Thread.Sleep(retrySleepTimeMilliseconds);
            }

            return null;
        }
    }
}