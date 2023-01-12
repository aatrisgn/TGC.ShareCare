using Microsoft.EntityFrameworkCore;
using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Models.Response;

namespace TGC.CareShare.WebAPI.Repositories;

public class ExpenseGroupInvitationRepository : BaseRepository<ExpenseGroupInvitation>, IExpenseGroupInvitationRepository
{
    public ExpenseGroupInvitationRepository(CareShareDBContext careShareDBContext) : base(careShareDBContext)
    {
    }

    public async Task<IEnumerable<ExpenseGroupInvitation>> GetAllBySenderId(Guid guid)
    {
        return await this.Context.Where(i => i.ProfileId == guid).ToListAsync();
    }

    public async Task<IEnumerable<ExpenseGroupInvitation>> GetAllByRecipientId(Guid guid)
    {
        return await this.Context.Where(i => i.InvitationProfileId == guid).ToListAsync();
    }
}
