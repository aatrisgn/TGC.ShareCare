using System.Security.Claims;

namespace TGC.CareShare.WebAPI.Services
{
    public interface IUserContext
    {
        void ExtractClaimsPrincipalAsync(ClaimsPrincipal user);
        Guid GetUserAADId();
        string GetUserEmail();

        string GetName();
    }
}
