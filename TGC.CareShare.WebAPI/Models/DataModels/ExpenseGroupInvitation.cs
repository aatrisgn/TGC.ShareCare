using TGC.CareShare.WebAPI.Models.Enums;
using TGC.CareShare.WebAPI.Models.Request;

namespace TGC.CareShare.WebAPI.Models.DataModels;

public class ExpenseGroupInvitation : DTOBaseClass
{
    public ExpenseGroupInvitation()
    {

    }
    public ExpenseGroupInvitation(InvitationRequest invitationRequest)
    {
        this.ExpenseGroupId = invitationRequest.ExpenseGroupId;
        this.InvitationProfileId = invitationRequest.InvitationProfileId;
        this.ProfileId = invitationRequest.ProfileId;
    }

    public InvitationStatus Acceptance { get; set; }
    public Guid ExpenseGroupId { get; set; }
    public ExpenseGroup ExpenseGroup { get; set; }
    public Guid InvitationProfileId { get; set; }
    public Profile InvitationProfile { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
}
