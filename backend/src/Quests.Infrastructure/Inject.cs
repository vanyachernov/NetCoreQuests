using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Quests.Application.TestDirectory;
using Quests.Application.UserDirectory;
using Quests.Infrastructure.Identity;
using Quests.Infrastructure.Repositories;

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
        
        services.AddScoped<IUsersRepository, UsersRepository>();
        
        services.AddScoped<ITestsRepository, TestsRepository>();
        
        services.AddScoped<JwtHandler>();
        
        
        return services;
    }
}