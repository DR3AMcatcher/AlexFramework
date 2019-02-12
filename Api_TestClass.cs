using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;

namespace AlexFramework
{
    class Api_TestClass : Api_TestFixture
    {
        [Test]
        [Order(1)]
        [Author("Alex Pidgirets")]
        [Category("API test")]
        public void ApiGet()
        {
            Get("/comments/2", "name", "quo vero reiciendis velit similique earum");
        }

        [Test]
        [Order(2)]
        [Author("Alex Pidgirets")]
        [Category("API test")]
        public void ApiPost()
        {
            Post("/posts", "userId", "123");
        }

        [Test]
        [Order(3)]
        [Author("Alex Pidgirets")]
        [Category("API test")]
        public void ApiDelete()
        {
            Delete("/posts/1");

        }
    }
}
