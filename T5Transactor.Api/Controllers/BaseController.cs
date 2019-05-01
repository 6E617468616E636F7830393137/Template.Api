using Autofac;
using System;
using System.Web.Http;
using T5Transactor.Api.Configuration;

namespace T5Transactor.Api.Controllers
{
    [RoutePrefix("api")]
    public class BaseController : ApiController
    {
        public Bll.BuildInformation.IBuildData BuildData { get; set; }
        public ISettings Settings { get; set; }
        public BaseController()
        {
            this.BuildData = Dependency_Injection.Container.container.Resolve<Bll.BuildInformation.IBuildData>();
            this.Settings = Dependency_Injection.Container.container.Resolve<ISettings>();
        }
        public BaseController(Bll.BuildInformation.IBuildData buildData, ISettings settings)
        {
            this.BuildData = buildData;
            buildData.setBuidInformation(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                Convert.ToDateTime(Properties.Resources.BuildDate).ToString()
                );
        }
    }
}
