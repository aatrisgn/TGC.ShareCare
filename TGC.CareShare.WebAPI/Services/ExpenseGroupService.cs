using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Repositories;

namespace TGC.CareShare.WebAPI.Services
{
    public class ExpenseGroupService : IExpenseGroupService
    {
        private readonly IExpenseGroupRepository _expenseGroupRepository;
        private readonly IExpenseGroupMemberService _expenseGroupMemberService;
        private readonly IProfileService _profileService;
        private readonly IUserContext _userContext;

        public ExpenseGroupService(
            IExpenseGroupRepository expenseGroupRepository,
            IExpenseGroupMemberService expenseGroupMemberService,
            IProfileService profileService,
            IUserContext userContext)
        {
            _expenseGroupRepository = expenseGroupRepository;
            _expenseGroupMemberService = expenseGroupMemberService;
            _profileService = profileService;
            _userContext = userContext;
        }
        public async Task<ExpenseGroup> CreateExpenseGroup(string expenseGroupName)
        {
            var expenseGroup = new ExpenseGroup() { Name = expenseGroupName };

            var profile = await _profileService.GetProfileByAzureIdAsync(_userContext.GetUserAADId());

            expenseGroup.ExpenseGroupMembers = new List<ExpenseGroupMember>();

            expenseGroup.ExpenseGroupMembers.Add(new ExpenseGroupMember()
            {
                ProfileId = profile.Id
            }); ;

            var newExpenseGroup = await _expenseGroupRepository.CreateAsync(expenseGroup);

            return newExpenseGroup;
        }

        public async Task<List<Guid>> GetAllIdsAsync()
        {
            return await _expenseGroupRepository.GetAllIdsAsync();
        }

        public async Task<List<ExpenseGroup>> GetAllByAzureIdAsync()
        {
            var profile = await _profileService.GetProfileByAzureIdAsync(_userContext.GetUserAADId());

            return await _expenseGroupRepository.GetAllByAzureIdAsync(profile.Id);
        }

        public async Task<List<Guid>> GetAllIdsByAzureIdAsync()
        {
            var profile = await _profileService.GetProfileByAzureIdAsync(_userContext.GetUserAADId());

            return await _expenseGroupRepository.GetAllIdsByAzureIdAsync(profile.Id);
        }

        public async Task<ExpenseGroup> GetById(Guid id)
        {
            return await _expenseGroupRepository.GetByIdAsync(id);
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
