using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Tests
{
    [TestClass]
    public class Genderize
    {
        private const string API_PATH = "https://api.genderize.io";
        [TestMethod]
        [GenderizeOkData]
        public void GetResponseOK(string value)
        {
            var builder =  new QueryBuilder();
            builder.Add("name", value);
            var actual = API_PATH + builder.ToString();
            using (var client = new HttpClient())
            {
                var request = client.GetAsync(actual);
                request.Wait();
                var respone = request.Result;
                Assert.AreEqual(HttpStatusCode.OK, respone.StatusCode);
            }
        }
        [TestMethod]
        public void GetResponseFAIL()
        {
            var builder = new QueryBuilder();
            var actual = API_PATH + builder.ToString();
            using (var client = new HttpClient())
            {
                var request = client.GetAsync(actual);
                request.Wait();
                var respone = request.Result;
                Assert.AreEqual(HttpStatusCode.UnprocessableEntity, respone.StatusCode);
            }
        }
        [TestMethod]
        [GenderizeResultsData]
        public void GetResponseResultsOkay(string value, string expected)
        {
            var builder = new QueryBuilder();
            builder.Add("name", value);
            var actual = API_PATH + builder.ToString();
            using (var client = new HttpClient())
            {
                var request = client.GetAsync(actual);
                request.Wait();
                var respone = request.Result;
                var stuff = respone.Content.ReadAsStringAsync().Result;
                Console.WriteLine(stuff);
                Assert.IsTrue(stuff.Contains(expected));
            }
        }
    }
}
