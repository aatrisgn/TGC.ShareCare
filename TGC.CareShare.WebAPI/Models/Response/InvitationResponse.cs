using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Models.Enums;

namespace TGC.CareShare.WebAPI.Models.Response;

public class InvitationResponse
{
    public InvitationResponse(ExpenseGroupInvitation expenseGroupInvitation)
    {
        this.Acceptance = expenseGroupInvitation.Acceptance;
        this.ExpenseGroupId = expenseGroupInvitation.ExpenseGroupId;
        this.InvitationProfileId = expenseGroupInvitation.InvitationProfileId;
        this.ProfileId = expenseGroupInvitation.ProfileId;
    }

    public InvitationStatus Acceptance { get; set; }
    public Guid ExpenseGroupId { get; set; }
    public Guid InvitationProfileId { get; set; }
    public Guid ProfileId { get; set; }
}
