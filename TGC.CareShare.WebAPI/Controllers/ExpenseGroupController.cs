using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;
using TGC.CareShare.WebAPI.Constants;
using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Models.Request;
using TGC.CareShare.WebAPI.Models.Response;
using TGC.CareShare.WebAPI.Repositories;
using TGC.CareShare.WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TGC.CareShare.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    [RequiredScope(AuthorizationScopes.OperationRead)]
    public class ExpenseGroupController : ControllerBase
    {
        private readonly IExpenseGroupService _expenseGroupService;
        public ExpenseGroupController(IExpenseGroupService expenseGroupService)
        {
            _expenseGroupService = expenseGroupService;
        }
        // GET: api/<ExpenseGroupController>
        [HttpGet]
        public async Task<List<Guid>> GetAllIds()
        {
            return await _expenseGroupService.GetAllIdsByAzureIdAsync();
        }

        [HttpGet("details")]
        public async Task<List<ExpenseGroup>> GetAllWithDetails()
        {
            return await _expenseGroupService.GetAllByAzureIdAsync();
        }

        // GET api/<ExpenseGroupController>/5
        [HttpGet("{id}")]
        public async Task<ExpenseGroup> GetExpenseGroup(Guid id)
        {
            return await _expenseGroupService.GetById(id);
        }

        // POST api/<ExpenseGroupController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] ExpenseGroupRequest expenseGroupRequest)
        {
            if (expenseGroupRequest.Name.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(expenseGroupRequest));
            }

            var newExpensegroup = await _expenseGroupService.CreateExpenseGroup(expenseGroupRequest.Name);

            return newExpensegroup.Id;
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
