using Microsoft.Extensions.DependencyInjection;
using Quests.Application.TestDirectory.AddTest;

namespace Quests.Application;

public static class Inject
{
    public static IServiceCollection AddAppliaction(this IServiceCollection services)
    {
        services.AddScoped<AddTestHandler>();
        
        return services;
    }
}