using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public interface IExpenseGroupRepository : IBaseRepository<ExpenseGroup>
    {
        Task<List<Guid>> GetAllIdsByAzureIdAsync(Guid profileId);
        Task<List<ExpenseGroup>> GetAllByAzureIdAsync(Guid id);
    }
}
