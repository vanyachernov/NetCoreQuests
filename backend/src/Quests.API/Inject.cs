using Microsoft.EntityFrameworkCore;
using Quests.Infrastructure;

namespace Quests.API;

public static class Inject
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        DotNetEnv.Env.Load();
        
        services.AddDbContext<QuestDbContext>(options =>
        {
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "QuestsDb";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "user";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";

            var connectionString = $"Host={dbServer};" +
                                   $"Port={dbPort};" +
                                   $"Database={dbName};" +
                                   $"Username={dbUser};" +
                                   $"Password={dbPassword};" +
                                   "Trust Server Certificate=true;";

            options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });
        
        return services;
    }
}