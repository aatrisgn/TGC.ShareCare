using Microsoft.EntityFrameworkCore;
using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(CareShareDBContext careShareDBContext) : base(careShareDBContext)
        {
        }

        public async Task<bool> ExistsByAzureIdAsync(Guid azureId)
        {
            return await Context.AnyAsync(t => t.AzureId == azureId);
        }

        public async Task<Profile> GetProfileByAzureIdAsync(Guid azureId)
        {
            return await Context.SingleAsync(t => t.AzureId == azureId);
        }
    }
}
