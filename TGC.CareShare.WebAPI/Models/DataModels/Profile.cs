namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class Profile : DTOBaseClass
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<ExpenseGroupMember> Memberships { get; set; }
    }
}
