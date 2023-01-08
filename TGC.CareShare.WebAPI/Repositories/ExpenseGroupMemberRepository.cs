using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public class ExpenseGroupMemberRepository : BaseRepository<ExpenseGroupMember>, IExpenseGroupMemberRepository
    {
        public ExpenseGroupMemberRepository(CareShareDBContext careShareDBContext) : base(careShareDBContext)
        {
        }
    }
}
