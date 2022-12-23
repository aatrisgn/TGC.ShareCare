using Microsoft.CodeAnalysis.CSharp.Syntax;
using TGC.CareShare.WebAPI.Repositories;
using TGC.CareShare.WebAPI.Services;

namespace TGC.CareShare.WebAPI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection )
        {
            serviceCollection.AddScoped<IExpenseGroupRepository, ExpenseGroupRepository>();

            serviceCollection.AddScoped<IExpenseGroupService, ExpenseGroupService>();

            return serviceCollection;
        }
    }
}
