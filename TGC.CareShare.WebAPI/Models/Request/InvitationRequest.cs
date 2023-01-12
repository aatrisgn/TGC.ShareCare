using TGC.CareShare.WebAPI.Models.Enums;

namespace TGC.CareShare.WebAPI.Models.Request;

public class InvitationRequest
{
    public Guid Id { get; set; }
    public Guid ExpenseGroupId { get; set; }
    public Guid InvitationProfileId { get; set; }
    public Guid ProfileId { get; set; }
    public InvitationStatus Acceptance {get;set;}
}
