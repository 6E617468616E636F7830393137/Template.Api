namespace Template.Api.Bll.BuildInformation
{
    public interface IBuildData
    {
        Dto.BuildInformation.Version  getBuildInformation();
        void setBuidInformation(string version, string date);        
    }
}
