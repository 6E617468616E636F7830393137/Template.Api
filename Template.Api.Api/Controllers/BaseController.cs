using System;
using System.Web.Http;
using Template.Api.Api.Configuration;

namespace Template.Api.Api.Controllers
{
    [RoutePrefix("api")]
    public class BaseController : ApiController
    {
        protected Bll.BuildInformation.IBuildData buildData { get; set; }
        protected ISettings settings { get; set; }
        public BaseController()
        {

        }
        public BaseController(Bll.BuildInformation.IBuildData buildData, ISettings settings)
        {
            this.buildData = buildData;
            buildData.setBuidInformation(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                Convert.ToDateTime(Properties.Resources.BuildDate).ToString()
                );
        }
    }
}
