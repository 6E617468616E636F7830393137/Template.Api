using System;
using System.Configuration;

namespace Template.Api.Api.Configuration
{
    public class Settings : ISettings
    {
        public string DisableSwagger { get; } = ConfigurationManager.AppSettings["DisableSwagger"];
        public Version BuildVersion { get; } = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public DateTime BuildDate { get; } = Convert.ToDateTime(Properties.Resources.BuildDate);
        public string DisableVersionCustomFilter { get; } = ConfigurationManager.AppSettings["DisableVersionCustomFilter"];
    }
}