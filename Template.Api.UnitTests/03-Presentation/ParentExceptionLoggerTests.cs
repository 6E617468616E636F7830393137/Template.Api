using System;
using System.Web.Http.ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Template.Api.UnitTests._03_Presentation
{
    [TestClass]
    public class ParentExceptionLoggerTests
    {
        [TestMethod]
        public void ParentExceptionLoggerTest()
        {
            var data = new Api.ParentExceptionLogger();
            var exception = new ExceptionLoggerContext(new ExceptionContext(new Exception(), new ExceptionContextCatchBlock("Unit Test", true, false)));
            data.Log(exception);
            exception = new ExceptionLoggerContext(new ExceptionContext(new Exception(), new ExceptionContextCatchBlock("Unit Test", false, true)));
        }
    }
}
