namespace T5Transactor.Bll.BusinessTemplate
{
    public class Class : IClass
    {
        public string GetInfo()
        {
            return new Dto.WebModels.Models().message;
        }
    }
}
