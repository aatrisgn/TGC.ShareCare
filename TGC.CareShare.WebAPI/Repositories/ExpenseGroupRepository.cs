using Microsoft.EntityFrameworkCore;
using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public class ExpenseGroupRepository : BaseRepository<ExpenseGroup>, IExpenseGroupRepository
    {
        public ExpenseGroupRepository(CareShareDBContext careShareDBContext) : base(careShareDBContext)
        {
        }

        public async Task<List<ExpenseGroup>> GetAllByAzureIdAsync(Guid profileId)
        {
            return await Context.Where(e => e.ExpenseGroupMembers.Any(egm => egm.ProfileId == profileId)).ToListAsync();
        }

        public async Task<List<Guid>> GetAllIdsByAzureIdAsync(Guid profileId)
        {
            return await Context.Where(e => e.ExpenseGroupMembers.Any(egm => egm.ProfileId == profileId)).Select(t => t.Id).ToListAsync();
        }
    }
}
