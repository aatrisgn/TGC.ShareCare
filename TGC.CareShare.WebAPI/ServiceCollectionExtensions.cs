using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Caching.Memory;
using TGC.CareShare.WebAPI.Repositories;
using TGC.CareShare.WebAPI.Services;

namespace TGC.CareShare.WebAPI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection )
        {
            serviceCollection.AddScoped<IExpenseGroupRepository, ExpenseGroupRepository>();
            serviceCollection.AddScoped<IExpenseGroupMemberRepository, ExpenseGroupMemberRepository>();
            serviceCollection.AddScoped<IExpenseGroupInvitationRepository, ExpenseGroupInvitationRepository>();
            serviceCollection.AddScoped<IProfileRepository, ProfileRepository>();

            serviceCollection.AddScoped<IExpenseGroupService, ExpenseGroupService>();
            serviceCollection.AddScoped<IExpenseGroupMemberService, ExpenseGroupMemberService>();
            serviceCollection.AddScoped<IExpenseGroupInvitationService, ExpenseGroupInvitationService>();
            serviceCollection.AddScoped<IProfileService, ProfileService>();

            serviceCollection.AddScoped<IUserContext, UserContext>();

            serviceCollection.AddSingleton<IMemoryCache, MemoryCache>();

            return serviceCollection;
        }
    }
}
