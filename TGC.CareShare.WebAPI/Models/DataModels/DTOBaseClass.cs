namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class DTOBaseClass
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public bool Active { get; set; }
    }
}
