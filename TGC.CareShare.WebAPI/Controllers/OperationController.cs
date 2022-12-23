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
        [RequiredScope("operation.read")]
        [HttpGet("healthcheck/authorized")]
        public IActionResult AuthorizedIndex()
        {
            var some = HttpContext.User;
            return Ok("Working");
        }
    }
}
