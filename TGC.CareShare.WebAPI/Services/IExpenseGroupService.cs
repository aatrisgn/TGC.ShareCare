using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Services
{
    public interface IExpenseGroupService
    {
        Task<ExpenseGroup> CreateExpenseGroup(string expenseGroupName);
        Task<List<Guid>> GetAllIdsAsync();
    }
}
