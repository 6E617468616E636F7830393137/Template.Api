using System.Net;
using System.Net.Http;
using System.Web.Http;
using Log4net.Helper.Logging;
using Template.Api.Bll.BuildInformation;
using Template.Api.Bll.BusinessTemplate;

namespace Template.Api.Api.Controllers
{
    [RoutePrefix("api")]
    public class MainController : BaseController
    {
        private IClass Class { get; set; }
        public MainController()
        { }
        public MainController(IClass Class, IBuildData buildData) 
            : base (buildData)            
        {
            this.Class = Class;
            this.buildData = buildData;
            Logger.Info($": : : Calling MainController Constructor : : :");            
        }
        [Route("BuildVersion")]
        [HttpGet]
        public IHttpActionResult BuildVersion()
        {            
            return Ok($"{buildData.getBuildInformation().BuildVersion} " +
                $"({buildData.getBuildInformation().BuildDate})");            
        }
        [Route("HelloWorld")]
        [HttpPost]
        public IHttpActionResult HelloWorld([FromBody] string message)
        {
            return Ok($"{Class.GetInfo()} :: {message}");
        }
        [Route("HelloWorld")]
        [HttpPut]
        public IHttpActionResult PutHelloWorld([FromBody] string message)
        {
            return Ok($"{Class.GetInfo()} :: {message}");
        }
        [Route("HelloWorld2")]
        [HttpPatch]
        public IHttpActionResult PatchHelloWorld([FromBody] string message)
        {
            return Ok($"{Class.GetInfo()} :: {message}");
        }
        [AcceptVerbs("OPTIONS")]
        [Route("HelloWorld2")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Origin", "*localhost:007");
            resp.Headers.Add("Access-Control-Allow-Methods", "POST,PUT,PATCH,OPTIONS,GET,DELETE");
            resp.Headers.Add("Access-Control-Request-Headers", "content-type");
            resp.Headers.Add("Access-Control-Allow-Headers", "content-type");
            return resp;
        }

    }
}
