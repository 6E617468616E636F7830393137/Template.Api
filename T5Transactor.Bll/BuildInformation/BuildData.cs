using T5Transactor.Dto.BuildInformation;

namespace T5Transactor.Bll.BuildInformation
{
    public class BuildData : IBuildData
    {
        private Version version;
        public Version getBuildInformation()
        {
            return version;
        }

        public void setBuidInformation(string version, string date)
        {
            this.version = new Version {
                BuildVersion = version,
                BuildDate = date
            };
        }        
    }
}
