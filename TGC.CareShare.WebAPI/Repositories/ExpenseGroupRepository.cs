using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public class ExpenseGroupRepository : BaseRepository<ExpenseGroup>, IExpenseGroupRepository
    {
        public ExpenseGroupRepository(CareShareDBContext careShareDBContext) : base(careShareDBContext)
        {
        }
    }
}
