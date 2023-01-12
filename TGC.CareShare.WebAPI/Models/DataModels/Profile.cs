namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class Profile : DTOBaseClass
    {
        public Guid AzureId { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public ICollection<ExpenseGroupMember> Memberships { get; set; }
        public ICollection<ExpenseGroupInvitation> SentInvitations { get; set; }

        public ICollection<ExpenseGroupInvitation> ReceivedInvitations { get; set; }
    }
}
