
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Net;

namespace TextRPG.Tests
{
    public class StringBuilder
    {
        private const string API_PATH = "https://focus-api.kontur.ru/api3/";
        private const string token = "3208d29d15c507395db770d0e65f3711e40374df";
        public string MakeReq(string method, Dictionary<string, string> reqValues)
        {
            var builder = new QueryBuilder();
            var query = API_PATH + method;
            foreach(var value in reqValues)
            {
                builder.Add(value.Key, value.Value);
            }
            builder.Add("key", token);
            return query + builder.ToString();
        }

    }
    [TestClass]
    public class APICursorTests
    {
        [TestMethod]
        public void TestMakeReq()
        {
            var builder = new StringBuilder();
            var values = new Dictionary<string, string> { { "inn", "7708503727" } };
            var actual = builder.MakeReq("req", values);
            Assert.AreEqual("https://focus-api.kontur.ru/api3/req?inn=7708503727&key=3208d29d15c507395db770d0e65f3711e40374df",actual);
        }
        
        [TestMethod]
        [ResponseOKData]
        public void GetResponseOK(string key, string value)
        {
            var builder = new StringBuilder();
            var values = new Dictionary<string, string> { { key, value } };
            var actual = builder.MakeReq("req", values);
            using(var client = new HttpClient())
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
            var builder = new StringBuilder();
            var values = new Dictionary<string, string> { { "inn", "" } };
            var actual = builder.MakeReq("req", values);
            using (var client = new HttpClient())
            {
                var request = client.GetAsync(actual);
                request.Wait();
                var respone = request.Result;
                Assert.AreEqual(HttpStatusCode.BadRequest, respone.StatusCode);
            }
        }
        [TestMethod]
        [ResponseResultsData]
        public void GetResponseResultsOkay(string key, string value, string expected)
        {
            var builder = new StringBuilder();
            var values = new Dictionary<string, string> { { key, value } };
            var actual = builder.MakeReq("req", values);
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
