using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace TGC.CareShare.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OperationController : ControllerBase
    {
        [HttpGet("healthcheck")]
        public IActionResult Index()
        {
            return Ok("Working");
        }

        [Authorize]
        [RequiredScope("operations.read")]
        [HttpGet("healthcheck/authorized")]
        public IActionResult AuthorizedIndex()
        {
            return Ok("Working");
        }
    }
}
