using System;
using System.Web.Http.ExceptionHandling;
using Logger = Log4net.Helper.Logging.Logger;

namespace T5Transactor.Api
{
    public class ParentExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            try
            {
                Logger.Fatal($"Unhandled exception occurred on server '{Environment.MachineName}' while processing {context.Request.Method.ToString()} for {context.Request.RequestUri.ToString()}", context.Exception);
            }
            catch (Exception)
            {
                Console.WriteLine($"Unhandled exception occurred on server '{Environment.MachineName}'", context.Exception);
            }
        }
    }
}
