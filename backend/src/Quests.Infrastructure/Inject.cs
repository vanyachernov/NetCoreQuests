using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Quests.Application.TestDirectory;
using Quests.Infrastructure.Identity;
using Quests.Infrastructure.Repositories;

namespace Quests.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<QuestDbContext>();
        
        services.AddScoped<ITestsRepository, TestsRepository>();
        
        return services;
    }
}