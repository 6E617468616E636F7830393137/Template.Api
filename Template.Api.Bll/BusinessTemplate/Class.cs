namespace Template.Api.Bll.BusinessTemplate
{
    public class Class : IClass
    {
        public string GetInfo()
        {
            return new Dto.WebModels.Models().message;
        }
    }
}
