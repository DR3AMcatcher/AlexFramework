using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using NUnit.Framework;
using System.Net;

namespace AlexFramework
{
    public class Api_TestFixture
    {
        private string EndPoint { get; set; }
        public static RestClient Client { get; set; }
        public RestRequest Request { get; set; }
        public IRestResponse Response { get; set; }
        public JObject ResponseJson { get; set; }
        private void SetUp()
        {
            EndPoint = "https://jsonplaceholder.typicode.com/";
        }
        public void Initialize()
        {
            SetUp();
            Client = new RestClient
            {
                BaseUrl = new System.Uri(EndPoint),
                Timeout = 3000
            };
        }

        public void Get(string path, string token, string valueToCheck)
        {
            Initialize();
            Request = new RestRequest(path, Method.GET);
            Response = Client.Get(Request);
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            ResponseJson = JObject.Parse(Response.Content);
            string value = (string)ResponseJson.SelectTokens(token).FirstOrDefault();
            StringAssert.AreEqualIgnoringCase(value, valueToCheck);
        }

        public void Post(string path, string token, string value)
        {
            Initialize();
            Request = new RestRequest("/posts", Method.POST);
            Request.RequestFormat = DataFormat.Json;
            Request.AddParameter(token, value);
            Response = Client.Execute(Request);
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        public void Delete(string path)
        {
            Initialize();
            Request = new RestRequest(path, Method.DELETE);
            Response = Client.Execute(Request);
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
