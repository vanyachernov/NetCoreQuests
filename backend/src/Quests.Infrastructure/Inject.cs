using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Quests.Application.TestDirectory;
using Quests.Infrastructure.Identity;

namespace Quests.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(option =>
            {
                option.Password.RequiredLength = 7;
                option.Password.RequireDigit = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<QuestDbContext>();
        
        services.AddScoped<ITestsRepository, TestsRepository>();
        
        return services;
    }
}