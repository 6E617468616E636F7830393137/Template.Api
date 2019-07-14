using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Template.Api.UnitTests._02_Business
{
    [TestClass]
    public class BllTests
    {
        
        [TestInitialize]
        public void Initialize()
        {
            
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
