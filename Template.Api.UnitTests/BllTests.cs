using Microsoft.VisualStudio.TestTools.UnitTesting;
using Template.Api.Bll.BusinessTemplate;

namespace Template.Api.UnitTests
{
    [TestClass]
    public class BllTests
    {
        //private IClass _Class;
        private Class _class;
        [TestInitialize]
        public void Initialize()
        {
            //_Class = Class;
        }
        [TestMethod]
        public void TestMethodIClass()
        {
            _class = new Class();
            var x = _class.GetInfo();
        }
    }
}
