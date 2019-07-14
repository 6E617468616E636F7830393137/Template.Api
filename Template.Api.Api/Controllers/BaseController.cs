using Autofac;
using System;
using System.Web.Http;
using Template.Api.Api.Configuration;

namespace Template.Api.Api.Controllers
{
    [RoutePrefix("api")]
    public class BaseController : ApiController
    {
        public ISettings Settings { get; set; }
        public BaseController()
        {
            this.Settings = DiContainer.container.Resolve<ISettings>();
        }
        public BaseController(ISettings settings)
        {
            Settings = settings;
        }
    }
}
