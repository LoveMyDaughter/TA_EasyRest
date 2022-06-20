using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NLog;
using RestSharp;
using System.Runtime.Serialization;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Xml.Serialization;
using TestFramework.Tools;
using NUnit.Allure.Core;

namespace TestFramework
{
    [AllureNUnit]
    [TestFixture]
    public class RestTest : TestRunner
    {
        public new Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        private string JsonToken;

       // [Test]
        public void VerifyItems()
        {
            log.Info("Start");
            string url = "https://localhost:8080/";
            var client = new RestClient(url);
            var request = new RestRequest("/items", Method.GET);
            request.AddParameter("token", "O4W7NGT4UNY6R6JN1T82O9N6M7IMEDI2");
            // Execute Request
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("content: " + content);
            Assert.True(content.Contains("romanukhaav"));
            log.Info("content: " + content);
        }

       // [Test]
        public void VerifyLogin()
        {
            log.Info("Start");
            string url = "https://127.0.0.1:8080/";
            var client = new RestClient(url);
            var request = new RestRequest("opencart/index.php?route=api/login", Method.POST);
            //
            //request.AddParameter("login", "admin", ParameterType.RequestBody);
            //request.AddParameter("password", "qwerty", ParameterType.RequestBody);
            //request.AddQueryParameter("login", "admin");
            //request.AddQueryParameter("password", "qwerty");
            //

            //request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW",
            //    "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"name\"\r\n\r\nadmin\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"password\"\r\n\r\nqwerty\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--",

            request.AddParameter("username","Default"); 
            request.AddParameter("key", "j0M724bQvkcrVst6XJfafMfzNShlBx0W5PGnh2WkBy4sxPrpCk3hSqA2xAm2AHPZXynNAQEPJcOHgdPTuLSZdM1Il4wZ6vgk6Fvye0i5jSNEFIFk5s7tmKIMSItCeyYM2kLEMqaLe5mSgKOyIRTaGZq4TdPd44DleW2Q3qqfEW3jean6FbsPaCSbQeQWRqMXL5bmNWb4oFWufPMkozLdVofXUU3pY2lEZc32p6Tta1HzPUoD0APR4fCRGksv8RK6");

            // Execute Request
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("content: " + content);
            string token = content.Substring(content.IndexOf(":\"") + 2);
            token = token.Substring(0, token.Length - 2);
            Console.WriteLine("token: " + token + " Length= " + content.Length);
            Assert.True(content.Length == 46);
            log.Info("token= " + token);
        }
        
        //[Test,Order(1)]
        public void VerifyLogin2()
        {
            log.Info("Start");
            var client = new RestClient("http://127.0.0.1/opencart/index.php?route=api/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("username", "Default");
            request.AddHeader("key", "j0M724bQvkcrVst6XJfafMfzNShlBx0W5PGnh2WkBy4sxPrpCk3hSqA2xAm2AHPZXynNAQEPJcOHgdPTuLSZdM1Il4wZ6vgk6Fvye0i5jSNEFIFk5s7tmKIMSItCeyYM2kLEMqaLe5mSgKOyIRTaGZq4TdPd44DleW2Q3qqfEW3jean6FbsPaCSbQeQWRqMXL5bmNWb4oFWufPMkozLdVofXUU3pY2lEZc32p6Tta1HzPUoD0APR4fCRGksv8RK6");
      //      request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
      //      request.AddHeader("Cookie", "OCSESSID=bf91ec90aba413c4745cae7240; currency=USD; language=en-gb");
            request.AddParameter("username", "Default");
            request.AddParameter("key", "j0M724bQvkcrVst6XJfafMfzNShlBx0W5PGnh2WkBy4sxPrpCk3hSqA2xAm2AHPZXynNAQEPJcOHgdPTuLSZdM1Il4wZ6vgk6Fvye0i5jSNEFIFk5s7tmKIMSItCeyYM2kLEMqaLe5mSgKOyIRTaGZq4TdPd44DleW2Q3qqfEW3jean6FbsPaCSbQeQWRqMXL5bmNWb4oFWufPMkozLdVofXUU3pY2lEZc32p6Tta1HzPUoD0APR4fCRGksv8RK6");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);

            JsonToken = data.api_token;
            Console.WriteLine(data.api_token);
        }

        //[Test,Order(2)]
        public void ReadCart()
        {
            log.Info("Start");
            var client = new RestClient("http://127.0.0.1/opencart/index.php?route=api/cart/products&api_token=" + JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", $"OCSESSID={JsonToken}; currency=USD; language=en-gb");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }

        [Test]
        public void ReadData1()
        {
            log.Info("Start");
            //
           // ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //
            string url = "http://127.0.0.1/opencart/index.php?route=product/product&product_id=42";
            var client = new RestClient(url);
            //var request = new RestRequest("/orgs/dotnet/repos", Method.GET);
            var request = new RestRequest(Method.GET);
            //
            request.AddHeader("Postman-Token", "b69e2907-9b7f-48d9-864d-728250f852bd");
            request.AddHeader("Cache-Control", "no-cache");
            //
            // Execute Request
            IRestResponse response = client.Execute(request);
            Console.WriteLine("IsSuccessful: " + response.IsSuccessful);
            var content = response.Content;
            Console.WriteLine("content: " + content);
            Assert.True(content.Contains(" Digital Video Interface (DVI) interface"));
            log.Info("done ");
        }

        [Test]
        public void ReadData2()
        {
            log.Info("Start");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //
            string url = "https://github.com/RV2021ATQC/CrashCourseAT";
            // Create WebClient
            using (var webClient = new WebClient())
            {
                webClient.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                    "(compatible; MSIE 6.0; Windows NT 5.1; " +
                    ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                //
                // get response
                var response = webClient.DownloadString(url);
                Console.WriteLine(response);
            }
            log.Info("done ");
        }

       // [Test]
        public void ReadDatabase()
        {

            DBConnectionWrapper.GetFirstnameById("2");
        }

    }
}
