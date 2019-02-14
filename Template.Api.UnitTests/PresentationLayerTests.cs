using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using Template.Api.Bll.BusinessTemplate;
using Template.Api.Bll.BuildInformation;

namespace Template.Api.UnitTests
{
    [TestClass]
    public class PresentationLayerTests
    {
        public string apiUrl = "";
        public string apiGetMessageUri = "";
        public string apiPostMessageUri = "";
        public string contentTypeJson = "";
        public string message = $"{"Message"}:{"No Token"}";

        private IClass Class { get; set; }
        private IBuildData BuildData { get; set; }

        [TestMethod]
        public void InitializeApiTest()
        {
            // Arrange
            Template.Api.Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act
            var wa = new Api.WebApiApplication();
            Api.WebApiConfig.Register(new HttpConfiguration());
            Api.Dependency_Injection.Container container = new Api.Dependency_Injection.Container();
            // Assert
            // Not applicable
        }
        [TestMethod]
        public void OptionsControllerTest()
        {
            // Arrange
            Template.Api.Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act
            HttpResponseMessage responseMessage = InitController().Options();
            // Assert
            Assert.AreEqual(responseMessage.IsSuccessStatusCode, true);
        }
        // Additional Extension Methods
        public Api.Controllers.MainController InitController()
        {
            var controller = new Api.Controllers.MainController();
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            var configuration = new HttpConfiguration();
            var requestContext = new HttpRequestContext();
            // Adding header
            request.Headers.Add("test", "test");

            controllerContext.Request = request;
            controllerContext.RequestContext = requestContext;
            controller.ControllerContext = controllerContext;
            controller.Configuration = configuration;
            return controller;
        }
        public string GetMethodCall(string keyName, string keyValue)
        {
            byte[] data;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                $"{apiUrl}{apiGetMessageUri}"
                );
            request.Method = "GET";
            request.ContentType = contentTypeJson;
            if (keyName != null)
            {
                request.Headers.Add(keyName, keyValue);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                data = new byte[response.ContentLength];
                using (Stream stream = response.GetResponseStream())
                {
                    int bytesRead = 0;
                    while (bytesRead < data.Length)
                    {
                        bytesRead += stream.Read(data, bytesRead, data.Length);
                    }
                }
                Console.WriteLine($"Response : {Encoding.UTF8.GetString(data)}");
                return Encoding.UTF8.GetString(data);
            }
        }
        public string PostMethodCall(string keyName, string keyValue)
        {
            byte[] postBytes;
            HttpWebRequest webReqeust = (HttpWebRequest)HttpWebRequest.Create($"{apiUrl}{apiPostMessageUri}");
            // webrequest.KeepAlive = false;
            // webrequest.AllowWriteStreamBuffering = false;
            // Convert object to string

            postBytes = Encoding.ASCII.GetBytes(message);

            webReqeust.Method = "POST";
            webReqeust.ContentType = contentTypeJson;
            webReqeust.ContentLength = postBytes.Length;
            if (keyName != null)
            {
                webReqeust.Headers.Add(keyName, keyValue);
            }

            using (Stream requestStream = webReqeust.GetRequestStream())
            {
                requestStream.Write(postBytes, 0, postBytes.Length);
            }
            // Get respnose
            using (HttpWebResponse webResponse = (HttpWebResponse)webReqeust.GetResponse())
            {
                string output = "";
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    output = reader.ReadToEnd().Trim();
                }
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Content = new StringContent(output, System.Text.Encoding.UTF8, "text/plain");
                return output; //resp.Content.ToString();
            }
        }
    }
}
