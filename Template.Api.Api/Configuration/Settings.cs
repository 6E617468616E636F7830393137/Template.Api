using System.Configuration;

namespace Template.Api.Api.Configuration
{
    public class Settings : ISettings
    {
        public string DisableSwagger { get; } = ConfigurationManager.AppSettings["DisableSwagger"];
    }
}