using Microsoft.VisualStudio.TestTools.UnitTesting;
using T5Transactor.Bll.BusinessTemplate;

namespace T5Transactor.UnitTests._02_Business
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
