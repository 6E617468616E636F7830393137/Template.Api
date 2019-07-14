using Autofac;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Template.Api.Api.Filters
{
    public class VersionCustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Check if filter is enabled
            if (DiContainer.container.Resolve<Configuration.ISettings>().DisableVersionCustomFilter.ToUpper() == "TRUE")
            {
                return;
            }
            // pre-processing
            else
            {

            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Check if filter is enabled
            if (DiContainer.container.Resolve<Configuration.ISettings>().DisableVersionCustomFilter.ToUpper() == "TRUE")
            {
                return;
            }
            // post-processing
            else
            {

            }
        }
    }
}