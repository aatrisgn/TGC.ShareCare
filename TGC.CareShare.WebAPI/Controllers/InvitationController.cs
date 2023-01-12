using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TGC.CareShare.WebAPI.Constants;
using TGC.CareShare.WebAPI.Models.Request;
using TGC.CareShare.WebAPI.Models.Response;
using TGC.CareShare.WebAPI.Services;

namespace TGC.CareShare.WebAPI.Controllers;

[Route("api/v1/invitations")]
[ApiController]
[Authorize]
[RequiredScope(AuthorizationScopes.OperationRead)]
public class InvitationController : ControllerBase
{
    private readonly IExpenseGroupInvitationService _expenseGroupInvitationService;
    public InvitationController(IExpenseGroupInvitationService expenseGroupInvitationService)
    {
        _expenseGroupInvitationService = expenseGroupInvitationService;
    }

    // GET: api/<InvitationController>
    [HttpGet("Received")]
    public async Task<IEnumerable<InvitationResponse>> GetRecievedInvitations()
    {
        return await _expenseGroupInvitationService.GetReceivedInvitations();
    }

    [HttpGet("sent")]
    public async Task<IEnumerable<InvitationResponse>> GetSentInvitations()
    {

        return await _expenseGroupInvitationService.GetSentInvitations();
    }

    // GET api/<InvitationController>/5
    [HttpGet("{id}")]
    public async Task<InvitationResponse> GetInvitation(Guid id)
    {
        return await _expenseGroupInvitationService.GetInvitationById(id);
    }

    // POST api/<InvitationController>
    [HttpPost]
    public async Task<InvitationResponse> Post([FromBody] InvitationRequest invitationRequest)
    {
        return await _expenseGroupInvitationService.CreateNewInvitation(invitationRequest);
    }

    // PUT api/<InvitationController>/5
    [HttpPut("{id}")]
    public async Task Put(Guid id, [FromBody] InvitationRequest invitationRequest)
    {
        await _expenseGroupInvitationService.UpdateInvitation(id, invitationRequest);
    }
}
