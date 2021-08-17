using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using Newtonsoft.Json;
using Web_Sevice.Models;

namespace Web_Sevice
{
    public class Tests : BaseTest
    {
        [Test]
        public static async Task TestTheStatusCode()
        {
            var response = await HttpClient.GetAsync(URL);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public static async Task TestTheContentType()
        {
            var response = await HttpClient.GetAsync(URL);
            Assert.IsTrue(response.Content.Headers.ContentType.CharSet.Equals("utf-8"));
            Assert.IsTrue(response.Content.Headers.ContentType.MediaType.Equals("application/json"));
        }

        [Test]
        public static async Task TestTheContentOfTheResponse()
        {
            var response = await HttpClient.GetAsync(URL);
            string jsonString = await response.Content.ReadAsStringAsync();
            List<Users> users = JsonConvert.DeserializeObject<List<Users>>(jsonString);
            Assert.AreEqual(users.Count, 10);
        }
    }
}
