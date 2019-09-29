using System.Net;
using System.Net.Http;
using System.Web.Http;
using Log4net.Helper.Logging;
using Template.Api.Api.Configuration;
using Swashbuckle.Swagger.Annotations;
using Autofac;
using Template.Api.Api.Filters;
using System.Threading.Tasks;

namespace Template.Api.Api.Controllers
{
    [RoutePrefix("api")]
    public class MainController : BaseController
    {
        public MainController()
            : base()
        {
            
        }
        public MainController(
            ISettings settings) 
            : base (settings)            
        {              
            this.Settings = settings;
            Logger.Info($": : : Calling MainController Constructor : : :");
        }
        /// <summary>Gets build information for API.</summary>
        /// <remarks>Gets build information for API.
        /// 
        /// No Request Model
        /// 
        /// </remarks>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type= typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError, Type = typeof(string))]
        [Route("Version")]
        [VersionCustomFilter]
        [HttpGet]
        public async Task<IHttpActionResult> Version()
        {         
            
            return Ok($"{Settings.BuildVersion.ToString()} : : : {Settings.BuildDate.ToString()}");            
        }
        /// <summary>Post generic request message for API.</summary>
        /// <remarks>Post generic request and returns response message from API.
        /// 
        /// message:"input message"
        /// 
        /// </remarks>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError, Type = typeof(string))]
        [Route("HelloWorld")]
        [HttpPost]
        public async Task<IHttpActionResult> PostHelloWorld([FromBody] string message)
        {
            return Ok($"{message}");
        }
        /// <summary>Put generic request message for API.</summary>
        /// <remarks>Put generic request and returns response message from API.
        /// 
        /// message:"input message"
        /// 
        /// </remarks>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError, Type = typeof(string))]
        [Route("HelloWorld")]
        [HttpPut]
        public async Task<IHttpActionResult> PutHelloWorld([FromBody] string message)
        {
            return Ok("");
        }
        /// <summary>Patch generic request message for API.</summary>
        /// <remarks>Patch generic request and returns response message from API.
        /// 
        /// message:"input message"
        /// 
        /// </remarks>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError, Type = typeof(string))]
        [Route("HelloWorld2")]
        [HttpPatch]
        public async Task<IHttpActionResult> PatchHelloWorld([FromBody] string message)
        {
            return Ok($"{message}");
        }
        /// <summary>Options for returning response code for request.</summary>
        /// <remarks>Options for returning response code for request.  Used for preflight requests.
        /// 
        /// No Request Model
        /// 
        /// </remarks>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Type = typeof(string))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError, Type = typeof(string))]
        [AcceptVerbs("OPTIONS")]
        [Route("HelloWorld2")]
        public async Task<HttpResponseMessage> Options()
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
