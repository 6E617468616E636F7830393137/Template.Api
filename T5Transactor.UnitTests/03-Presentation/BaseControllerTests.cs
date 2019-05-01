using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using T5Transactor.Bll.BusinessTemplate;
using T5Transactor.Bll.BuildInformation;
using System.Web.Http.Results;
using System.Web;
using T5Transactor.Api;
using System.Web.Http.ExceptionHandling;
using System.Reflection;
using System.Configuration;

namespace T5Transactor.UnitTests._03_Presentation
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
            var baseControllerApi = (Api.Controllers.BaseController)assembly.CreateInstance("T5Transactor.Api.Controllers.BaseController");
            var data = baseControllerApi.Settings;
            // Assert
            Assert.AreEqual(data.DisableSwagger, ConfigurationManager.AppSettings["DisableSwagger"]);
        }
        // Additional Extension Methods
        public Api.Controllers.BaseController InitController()
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
