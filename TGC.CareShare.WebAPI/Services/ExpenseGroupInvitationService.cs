using TGC.CareShare.WebAPI.Exceptions;
using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Models.Enums;
using TGC.CareShare.WebAPI.Models.Request;
using TGC.CareShare.WebAPI.Models.Response;
using TGC.CareShare.WebAPI.Repositories;

namespace TGC.CareShare.WebAPI.Services;

public class ExpenseGroupInvitationService : IExpenseGroupInvitationService
{
    private readonly IExpenseGroupInvitationRepository _expenseGroupInvitationRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IUserContext _userContext;

    private readonly InvitationStatus[] validRecipientStatusChanges = new InvitationStatus[] {
        InvitationStatus.Declined,InvitationStatus.Accepted
    };
    private readonly InvitationStatus[] validSenderStatusChanges = new InvitationStatus[] {
        InvitationStatus.Cancelled
    };

    public ExpenseGroupInvitationService(
        IExpenseGroupInvitationRepository expenseGroupInvitationRepository,
        IProfileRepository profileRepository,
        IUserContext userContext)
    {
        _expenseGroupInvitationRepository = expenseGroupInvitationRepository;
        _profileRepository = profileRepository;
        _userContext = userContext;
    }

    public async Task<InvitationResponse> CreateNewInvitation(InvitationRequest invitationRequest)
    {
        var invitationProfile = await _profileRepository.GetProfileByAzureIdAsync(invitationRequest.InvitationProfileId);
        var senderProfile = await _profileRepository.GetProfileByAzureIdAsync(_userContext.GetUserAADId());

        invitationRequest.ProfileId = senderProfile.Id;
        invitationRequest.InvitationProfileId = invitationProfile.Id;

        var existingInvitations = await _expenseGroupInvitationRepository
            .AnyAsync(e => 
                e.InvitationProfileId == invitationProfile.Id
                && e.ProfileId == senderProfile.Id
                && e.ExpenseGroupId == invitationRequest.ExpenseGroupId
                && e.Active == false);

        if (existingInvitations == false)
        {
            var expenseGroupInvitation = new ExpenseGroupInvitation(invitationRequest);

            expenseGroupInvitation.Acceptance = InvitationStatus.Pending;

            var createdExpenseGroupInvitation = await _expenseGroupInvitationRepository.CreateAsync(expenseGroupInvitation);

            return new InvitationResponse(createdExpenseGroupInvitation);
        }

        throw new BadHttpRequestException("An existing invitation is already active.");        
    }

    public async Task<InvitationResponse> GetInvitationById(Guid id)
    {
        var expenseGroupInvitation = await _expenseGroupInvitationRepository.GetByIdAsync(id);

        if(expenseGroupInvitation != null)
        {
            var activeUserAzureId = _userContext.GetUserAADId();
            var user = await _profileRepository.GetProfileByAzureIdAsync(activeUserAzureId);

            if (userIsEitherSenderOrRecipient(user.Id, expenseGroupInvitation))
            {
                return new InvitationResponse(expenseGroupInvitation);
            }
        }

        throw new ExpenseGroupInvitationNotFoundException();
    }

    public async Task<IEnumerable<InvitationResponse>> GetReceivedInvitations()
    {
        var activeUserAzureId = _userContext.GetUserAADId();
        var user = await _profileRepository.GetProfileByAzureIdAsync(activeUserAzureId);

        var expenseGroupInvitations = await _expenseGroupInvitationRepository.GetAllByRecipientId(user.Id);
        return expenseGroupInvitations.Select(e => new InvitationResponse(e));
    }

    public async Task<IEnumerable<InvitationResponse>> GetSentInvitations()
    {
        var activeUserAzureId = _userContext.GetUserAADId();
        var user = await _profileRepository.GetProfileByAzureIdAsync(activeUserAzureId);

        var expenseGroupInvitations = await _expenseGroupInvitationRepository.GetAllBySenderId(user.Id);
        return expenseGroupInvitations.Select(e => new InvitationResponse(e));
    }

    public async Task UpdateInvitation(Guid id, InvitationRequest invitationRequest)
    {
        var expenseGroupInvitation = await _expenseGroupInvitationRepository.GetByIdAsync(invitationRequest.Id);
        var userId = _userContext.GetUserAADId();


        if (userIsEitherSenderOrRecipient(userId, expenseGroupInvitation))
        {
            if(userId == expenseGroupInvitation.InvitationProfileId) // User who is updating is recipient of invitation
            {
                if (validRecipientStatusChanges.Contains(invitationRequest.Acceptance))
                {
                    await UpdateExpenseGroupInvitation(invitationRequest, expenseGroupInvitation);
                }
            } 
            else if (userId == expenseGroupInvitation.ProfileId) // User who is sender of invitation
            {
                if (validSenderStatusChanges.Contains(invitationRequest.Acceptance))
                {
                    await UpdateExpenseGroupInvitation(invitationRequest, expenseGroupInvitation);
                }
            }
        }

        throw new ExpenseGroupInvitationNotFoundException();
    }

    private async Task UpdateExpenseGroupInvitation(InvitationRequest invitationRequest, ExpenseGroupInvitation expenseGroupInvitation)
    {
        expenseGroupInvitation.Acceptance = invitationRequest.Acceptance;
        await _expenseGroupInvitationRepository.Update(expenseGroupInvitation);
    }

    private bool userIsEitherSenderOrRecipient(Guid userId, ExpenseGroupInvitation invitationRequest)
    {
        return invitationRequest.InvitationProfileId == userId || invitationRequest.ProfileId == userId;
    }
}
