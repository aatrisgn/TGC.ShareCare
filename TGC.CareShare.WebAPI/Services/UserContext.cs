using System.Security.Claims;
using TGC.CareShare.WebAPI.Constants;

namespace TGC.CareShare.WebAPI.Services
{
    public class UserContext : IUserContext
    {
        private IEnumerable<Claim> Claims;

        public void ExtractClaimsPrincipalAsync(ClaimsPrincipal claimsPrincipal)
        {
            if(claimsPrincipal != null)
            {
                var identity = claimsPrincipal.Identity as ClaimsIdentity;

                if(identity != null)
                {
                    Claims = identity.Claims;
                }
            }
        }

        public Guid GetUserAADId()
        {
            var claimValue = GetClaimValue(CareShareClaimTypes.ObjectIdClaimType);

            if(string.IsNullOrEmpty(claimValue) == false)
            {
                return Guid.Parse(claimValue);
            }

            return Guid.Empty;
        }

        public string GetUserEmail()
        {
            return GetClaimValue(CareShareClaimTypes.EmailClaimType);
        }

        public string GetName()
        {
            return GetClaimValue(CareShareClaimTypes.GivenNameClaimType);
        }

        private string GetClaimValue(string claimValueType)
        {
            if(Claims != null)
            {
                var claimValue = Claims.FirstOrDefault(c => c.Type == claimValueType);
                if( claimValue != null)
                {
                    return claimValue.Value;
                }
            }
            return string.Empty;
        }
    }
}
