using System;
using System.Web.Http;

namespace Template.Api.Api.Controllers
{
    [RoutePrefix("api")]
    public class BaseController : ApiController
    {
        protected Bll.BuildInformation.IBuildData buildData { get; set; }

        public BaseController()
        {

        }
        public BaseController(Bll.BuildInformation.IBuildData buildData)
        {
            this.buildData = buildData;
            buildData.setBuidInformation(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                Convert.ToDateTime(Properties.Resources.BuildDate).ToString()
                );
        }
    }
}
