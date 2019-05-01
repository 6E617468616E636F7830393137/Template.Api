using System.Configuration;

namespace T5Transactor.Api.Configuration
{
    public class Settings : ISettings
    {
        public string DisableSwagger { get; } = ConfigurationManager.AppSettings["DisableSwagger"];
    }
}
