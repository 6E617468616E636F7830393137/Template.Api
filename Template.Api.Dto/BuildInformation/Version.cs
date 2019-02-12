using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Api.Dto.BuildInformation
{
    public class VersionData
    {
        public Version GatherVersionData {get; set;}
    }
    public class Version
    {        
        public string BuildVersion { get; set; }
        public string BuildDate { get; set; }
    }
}
