using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        Task<bool> ExistsByAzureIdAsync(Guid azureId);
        Task<Profile> GetProfileByAzureIdAsync(Guid azureId);
    }
}
