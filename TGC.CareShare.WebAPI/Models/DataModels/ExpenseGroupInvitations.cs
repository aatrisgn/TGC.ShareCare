using TGC.CareShare.WebAPI.Models.Enums;

namespace TGC.CareShare.WebAPI.Models.DataModels;

public class ExpenseGroupInvitations
{
    public InvitationStatus Acceptance { get; set; }
    public Guid ExpenseGroupId { get; set; }
    public ExpenseGroup ExpenseGroup { get; set; }
    public Guid InvitationProfileId { get; set; }
    public Profile InvitationProfile { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
}
