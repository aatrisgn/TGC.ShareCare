namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class User : DTOBaseClass
    {
        public Guid AzureId { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}