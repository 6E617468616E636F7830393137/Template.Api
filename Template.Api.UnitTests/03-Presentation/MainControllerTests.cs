using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web;
using Template.Api.Api;
using Template.Api.Bll.BuildInformation;

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
            Template.Api.Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act
            var wa = new Api.WebApiApplication();            
            Api.WebApiConfig.Register(new HttpConfiguration());
            Api.Dependency_Injection.Container container = new Api.Dependency_Injection.Container();

            SwaggerConfig.Register();
            
            // Assert
            // Not applicable
        }
        [TestMethod]
        public void MainControllerTest()
        {
            Api.Configuration.ISettings settings = new Api.Configuration.Settings();
            IBuildData buildData = new BuildData();
            Bll.BusinessTemplate.IClass iClass = new Bll.BusinessTemplate.Class();
            var controller = new Api.Controllers.MainController(iClass, buildData, settings);

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
        [TestMethod]
        public void GetBuildInformationTest()
        {
            // Arrange
            Template.Api.Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            var data = InitController();
            var buildData = data.BuildData;
            buildData.setBuidInformation(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                DateTime.Now.ToString()
                );
            // Act            
            IHttpActionResult responseMessage = data.BuildVersion();
            // Assert
            var responseMessageContent = ((OkNegotiatedContentResult<string>)(responseMessage)).Content;
            Assert.IsNotNull(responseMessageContent);
        }
        [TestMethod]
        public void PostControllerTest()
        {
            // Arrange
            Template.Api.Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act            
            var inputMessage = "Unit Test for Post.";
            IHttpActionResult responseMessage = InitController().PostHelloWorld(inputMessage);
            // Assert
            var outputMessage = $"Hello World :: {inputMessage}";
            var responseMessageContent = ((OkNegotiatedContentResult<string>)(responseMessage)).Content;
            Assert.AreEqual(outputMessage, responseMessageContent);
        }
        [TestMethod]
        public void PutControllerTest()
        {
            // Arrange
            Template.Api.Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act            
            var inputMessage = "Unit Test for Put.";
            IHttpActionResult responseMessage = InitController().PutHelloWorld(inputMessage);
            // Assert
            var outputMessage = $"Hello World :: {inputMessage}";
            var responseMessageContent = ((OkNegotiatedContentResult<string>)(responseMessage)).Content;
            Assert.AreEqual(outputMessage, responseMessageContent);
        }
        [TestMethod]
        public void PatchControllerTest()
        {
            // Arrange
            Template.Api.Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act            
            var inputMessage = "Unit Test for Patch.";
            IHttpActionResult responseMessage = InitController().PatchHelloWorld(inputMessage);
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
            // Adding header
            request.Headers.Add("test", "test");

            controllerContext.Request = request;
            controllerContext.RequestContext = requestContext;
            controller.ControllerContext = controllerContext;
            controller.Configuration = configuration;
            return controller;
        }        
    }
}
