using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Models.Response;

namespace TGC.CareShare.WebAPI.Repositories
{
    public interface IExpenseGroupInvitationRepository : IBaseRepository<ExpenseGroupInvitation>
    {
        Task<IEnumerable<ExpenseGroupInvitation>> GetAllByRecipientId(Guid guid);
        Task<IEnumerable<ExpenseGroupInvitation>> GetAllBySenderId(Guid guid);
    }
}
