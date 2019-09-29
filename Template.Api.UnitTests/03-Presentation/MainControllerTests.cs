using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web;
using Template.Api.Api;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Template.Api.UnitTests._03_Presentation
{
    [TestClass]
    public class MainControllerTests
    {
        public string apiUrl = "";
        public string apiGetMessageUri = "";
        public string apiPostMessageUri = "";
        public string contentTypeJson = "";
        public string message = $"{"Message"}:{"No Token"}";       

        [TestMethod]
        public void InitializeApiTest()
        {
            // Arrange
            DiContainer.Initialize(new HttpConfiguration());
            // Act
            var wa = new Api.WebApiApplication();            
            Api.WebApiConfig.Register(new HttpConfiguration());
            DiContainer container = new DiContainer();

            SwaggerConfig.Register();
            
            // Assert
            // Not applicable
        }
        [TestMethod]
        public void MainControllerTest()
        {
            Api.Configuration.ISettings settings = new Api.Configuration.Settings();
            var controller = new Api.Controllers.MainController(settings);

        }        
        [TestMethod]
        public void OptionsControllerTest()
        {
            // Arrange
            DiContainer.Initialize(new HttpConfiguration());
            // Act
            HttpResponseMessage responseMessage = InitController().Options().Result;
            // Assert
            Assert.AreEqual(responseMessage.IsSuccessStatusCode, true);
        }        
        [TestMethod]
        public void GetBuildInformationTest()
        {
            // Arrange
            DiContainer.Initialize(new HttpConfiguration());
            var data = InitController();            
            // Act            
            IHttpActionResult responseMessage = data.Version().Result;
            // Assert
            var responseMessageContent = ((OkNegotiatedContentResult<string>)(responseMessage)).Content;
            Assert.IsNotNull(responseMessageContent);
        }
        [TestMethod]
        public void PostControllerTest()
        {
            // Arrange
            DiContainer.Initialize(new HttpConfiguration());
            // Act            
            var inputMessage = "Unit Test for Post.";
            IHttpActionResult responseMessage = InitController().PostHelloWorld(inputMessage).Result;
            // Assert
            var outputMessage = $"Hello World :: {inputMessage}";
            var responseMessageContent = ((OkNegotiatedContentResult<string>)(responseMessage)).Content;
            Assert.AreEqual(outputMessage, responseMessageContent);
        }
        [TestMethod]
        public void PutControllerTest()
        {
            // Arrange
            DiContainer.Initialize(new HttpConfiguration());
            // Act            
            var inputMessage = "Unit Test for Put.";
            IHttpActionResult responseMessage = InitController().PutHelloWorld(inputMessage).Result;
            // Assert
            var outputMessage = $"Hello World :: {inputMessage}";
            var responseMessageContent = ((OkNegotiatedContentResult<string>)(responseMessage)).Content;
            Assert.AreEqual(outputMessage, responseMessageContent);
        }
        [TestMethod]
        public void PatchControllerTest()
        {
            // Arrange
            DiContainer.Initialize(new HttpConfiguration());
            // Act            
            var inputMessage = "Unit Test for Patch.";
            IHttpActionResult responseMessage = InitController().PatchHelloWorld(inputMessage).Result;
            // Assert
            var outputMessage = $"Hello World :: {inputMessage}";
            var responseMessageContent = ((OkNegotiatedContentResult<string>)(responseMessage)).Content;
            Assert.AreEqual(outputMessage, responseMessageContent);
        }
        // Additional Extension Methods
        private Api.Controllers.MainController InitController()
        {
            var controller = new Api.Controllers.MainController();
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            var configuration = new HttpConfiguration();
            var requestContext = new HttpRequestContext();

            controllerContext.Request = request;
            controllerContext.RequestContext = requestContext;
            controller.ControllerContext = controllerContext;
            controller.Configuration = configuration;
            return controller;
        }        
    }
}
