using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

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
    }
}
