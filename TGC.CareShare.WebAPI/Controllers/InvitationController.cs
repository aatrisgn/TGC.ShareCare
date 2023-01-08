using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TGC.CareShare.WebAPI.Constants;
using TGC.CareShare.WebAPI.Models.Request;
using TGC.CareShare.WebAPI.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TGC.CareShare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [RequiredScope(AuthorizationScopes.OperationRead)]
    public class InvitationController : ControllerBase
    {
        // GET: api/<InvitationController>
        [HttpGet("Recieved")]
        public IEnumerable<Guid> GetRecievedInvitations()
        {
            return new Guid[] { Guid.NewGuid()};
        }

        [HttpGet("Sent")]
        public IEnumerable<Guid> GetSentInvitations()
        {
            return new Guid[] { Guid.NewGuid() };
        }

        // GET api/<InvitationController>/5
        [HttpGet("{id}")]
        public InvitationResponse Get(Guid id)
        {
            return new InvitationResponse();
        }

        // POST api/<InvitationController>
        [HttpPost]
        public InvitationResponse Post([FromBody] InvitationRequest invitationRequest)
        {
            return new InvitationResponse();
        }

        // PUT api/<InvitationController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] InvitationRequest invitationRequest)
        {
        }

        // DELETE api/<InvitationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
