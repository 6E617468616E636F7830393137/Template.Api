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
using System.Web.Http.Results;
using System.Web;
using Template.Api.Api;
using System.Web.Http.ExceptionHandling;
using System.Reflection;
using System.Configuration;

namespace Template.Api.UnitTests._03_Presentation
{
    [TestClass]
    public class BaseControllerTests
    {
        [TestMethod]
        public void GetBuildDataTest()
        {
            // Arrange
            Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act
            var baseController = InitController();
            var data = baseController.BuildData;
            data.setBuidInformation(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                DateTime.Now.ToString()
                );
            // Assert
            Assert.IsNotNull(data.getBuildInformation().BuildDate);
            Assert.IsNotNull(data.getBuildInformation().BuildVersion);
            Assert.IsNotNull(data.getBuildInformation());
        }
        [TestMethod]
        public void GetSettings()
        {
            // Arrange
            Api.Dependency_Injection.Container.Initialize(new HttpConfiguration());
            // Act
            Assembly assembly = typeof(Api.Controllers.BaseController).Assembly;
            var baseControllerApi = (Api.Controllers.BaseController)assembly.CreateInstance("Template.Api.Api.Controllers.BaseController");
            var data = baseControllerApi.Settings;
            // Assert
            Assert.AreEqual(data.DisableSwagger, ConfigurationManager.AppSettings["DisableSwagger"]);
        }
        [TestMethod]
        public void BaseControllerTest()
        {
            Api.Configuration.ISettings settings = new Api.Configuration.Settings();
            IBuildData buildData = new BuildData();
            var controller = new Api.Controllers.BaseController(buildData, settings);
        }
        // Additional Extension Methods
        private Api.Controllers.BaseController InitController()
        {
            var controller = new Api.Controllers.BaseController();
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
