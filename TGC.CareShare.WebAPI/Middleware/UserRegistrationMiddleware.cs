using Microsoft.Extensions.Caching.Memory;
using TGC.CareShare.WebAPI.Services;

namespace TGC.CareShare.WebAPI.Middleware;

public class UserRegistrationMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));

    public UserRegistrationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserContext userContext, IProfileService profileService, IMemoryCache memoryCache)
    {
        var contextUser = context.User;

        userContext.ExtractClaimsPrincipalAsync(contextUser);

        if(userContext.GetUserAADId() != Guid.Empty)
        {
            if (IsUserRegistedInCache(userContext.GetUserAADId(), memoryCache) == false && await profileService.UserExists() == false)
            {
                await profileService.CreateUser();
            }
        }
        
        await _next(context);
    }

    private bool IsUserRegistedInCache(Guid azureId, IMemoryCache memoryCache)
    {
        var currentDateTime = DateTime.Now;

        if (!memoryCache.TryGetValue(azureId, out DateTime cacheValue))
        {
            cacheValue = currentDateTime;

            memoryCache.Set(azureId, cacheValue, memoryCacheEntryOptions);

            return false;
        }

        memoryCache.Set(azureId, currentDateTime, memoryCacheEntryOptions);

        return true;
    }
}