using Microsoft.VisualStudio.TestTools.UnitTesting;
using Template.Api.Bll.BusinessTemplate;

namespace Template.Api.UnitTests._02_Business
{
    [TestClass]
    public class BllTests
    {
        //private IClass _Class;
        private Class _class;
        [TestInitialize]
        public void Initialize()
        {
            
        }
        [TestMethod]
        public void TestMethodIClass()
        {
            _class = new Class();
            var x = _class.GetInfo();
        }
        [TestMethod]
        public void HeadersTest()
        {
            var webHeaders = new Dto.WebHeaders.Headers();            
            // Setters
            webHeaders.key = "Test2";
            webHeaders.value = "Test2";
            // Getters
            var key = webHeaders.key;
            var value = webHeaders.value;

        }
    }
}
