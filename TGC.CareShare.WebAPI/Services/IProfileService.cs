using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Services
{
    public interface IProfileService
    {
        Task<bool> UserExists();
        Task CreateUser();
        Task<Profile> GetProfileByAzureIdAsync(Guid azureId);
    }
}
