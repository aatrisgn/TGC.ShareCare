using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Repositories;

namespace TGC.CareShare.WebAPI.Services
{
    public class ExpenseGroupService : IExpenseGroupService
    {
        private readonly IExpenseGroupRepository _expenseGroupRepository;
        public ExpenseGroupService(IExpenseGroupRepository expenseGroupRepository)
        {
            _expenseGroupRepository = expenseGroupRepository;
        }
        public async Task<ExpenseGroup> CreateExpenseGroup(string expenseGroupName)
        {
            var expenseGroup = new ExpenseGroup() { Name = expenseGroupName };
            return await _expenseGroupRepository.CreateAsync(expenseGroup);
        }

        public async Task<List<Guid>> GetAllIdsAsync()
        {
            return await _expenseGroupRepository.GetAllIdsAsync();
        }

        public async Task UpdateNameAsync(Guid id, string name)
        {
            var expenseGroup = await _expenseGroupRepository.GetByIdAsync(id);
            expenseGroup.Name = name;
            _expenseGroupRepository.Update(expenseGroup);
        }

        public async Task DeleteExpenseGroupAsync(Guid id)
        {
            var expenseGroup = await _expenseGroupRepository.GetByIdAsync(id);
            expenseGroup.Deactivate();
            _expenseGroupRepository.Update(expenseGroup);
        }
    }
}
