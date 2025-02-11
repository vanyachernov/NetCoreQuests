using Microsoft.Extensions.DependencyInjection;
using Quests.Application.TestDirectory.AddTest;
using Quests.Application.TestDirectory.GetTestById;
using Quests.Application.TestDirectory.GetTests;

namespace Quests.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddTestHandler>();
        
        services.AddScoped<GetTestsHandler>();
        
        services.AddScoped<GetTestByIdHandler>();
        
        return services;
    }
}