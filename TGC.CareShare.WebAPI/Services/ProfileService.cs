using TGC.CareShare.WebAPI.Models.DataModels;
using TGC.CareShare.WebAPI.Repositories;

namespace TGC.CareShare.WebAPI.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserContext _userContext;
        private readonly IProfileRepository _profileRepository;
        public ProfileService(
            IProfileRepository profileRepository, 
            IUserContext userContext)
        {
            _profileRepository = profileRepository;
            _userContext = userContext;
        }

        public async Task CreateUser()
        {
            var newProfile = new Profile()
            {
                AzureId = _userContext.GetUserAADId(),
                Email = _userContext.GetUserEmail(),
                GivenName = _userContext.GetName()
            };

            await _profileRepository.CreateAsync(newProfile);
        }

        public async Task<Profile> GetProfileByAzureIdAsync(Guid azureId)
        {
            return await _profileRepository.GetProfileByAzureIdAsync(azureId);
        }

        public async Task<bool> UserExists()
        {
            var azureObjectId = _userContext.GetUserAADId();

            return await _profileRepository.ExistsByAzureIdAsync(azureObjectId);
        }
    }
}
