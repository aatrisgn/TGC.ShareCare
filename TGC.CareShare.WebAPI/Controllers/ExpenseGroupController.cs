using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TGC.CareShare.WebAPI.Models.Request;
using TGC.CareShare.WebAPI.Repositories;
using TGC.CareShare.WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TGC.CareShare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [RequiredScope("operation.read")]
    public class ExpenseGroupController : ControllerBase
    {
        private readonly IExpenseGroupService _expenseGroupService;
        public ExpenseGroupController(IExpenseGroupService expenseGroupService)
        {
            _expenseGroupService = expenseGroupService;
        }
        // GET: api/<ExpenseGroupController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _expenseGroupService.GetAllIdsAsync());
        }

        // GET api/<ExpenseGroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExpenseGroupController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseGroupRequest expenseGroupRequest)
        {
            var newExpensegroup = await _expenseGroupService.CreateExpenseGroup(expenseGroupRequest.Name);

            return Ok(newExpensegroup.Id);
        }

        // PUT api/<ExpenseGroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ExpenseGroupRequest expenseGroupRequest)
        {
        }

        // DELETE api/<ExpenseGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
