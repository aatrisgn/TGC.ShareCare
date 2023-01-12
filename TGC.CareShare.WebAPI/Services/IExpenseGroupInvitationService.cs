using TGC.CareShare.WebAPI.Models.Request;
using TGC.CareShare.WebAPI.Models.Response;

namespace TGC.CareShare.WebAPI.Services;

public interface IExpenseGroupInvitationService
{
    Task<IEnumerable<InvitationResponse>> GetReceivedInvitations();
    Task<IEnumerable<InvitationResponse>> GetSentInvitations();
    Task<InvitationResponse> GetInvitationById(Guid id);
    Task<InvitationResponse> CreateNewInvitation(InvitationRequest invitationRequest);
    Task UpdateInvitation(Guid id, InvitationRequest invitationRequest);
}
