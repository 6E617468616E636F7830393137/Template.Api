using Microsoft.VisualStudio.TestTools.UnitTesting;
using Template.Api.Bll.BusinessTemplate;

namespace Template.Api.UnitTests
{
    [TestClass]
    public class BllTests
    {
        private IClass Class;
        public void InitTest(IClass IClass)
        {
            this.Class = IClass;
        }
        [TestMethod]
        public void TestMethodIClass()
        {
            InitTest(this.Class);
            var data = this.Class.GetInfo();
        }
    }
}
