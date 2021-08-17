using System.Net.Http;
using System.Configuration;
using NUnit.Framework;

namespace Web_Sevice
{
    public class BaseTest
    {
        protected static string URL { get; set; }
        protected static HttpClient HttpClient { get; set; }

        [SetUp]
        public static void Init()
        {
            URL = ConfigurationManager.AppSettings["URL"];
            HttpClient = new HttpClient();
        }

        [TearDown]
        public static void TearDown()
        {
            HttpClient.Dispose();
        }
    }
}
