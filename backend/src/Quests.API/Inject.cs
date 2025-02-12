using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quests.Infrastructure;

namespace Quests.API;

public static class Inject
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        DotNetEnv.Env.Load();
        
        var jwtSecurityKey = Environment.GetEnvironmentVariable("JWT_SECRET");
        var jwtValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        var jwtValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

        services.AddDbContext<QuestDbContext>(options =>
        {
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "26957";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "defaultdb";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "avnadmin";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "here";

            var connectionString =
                $"Host={dbServer};"
                + $"Port={dbPort};"
                + $"Database={dbName};"
                + $"Username={dbUser};"
                + $"Password={dbPassword};"
                + "SSL Mode=Require;"
                + "Trust Server Certificate=true;";

            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtOptions =>
        {
            jwtOptions.UseSecurityTokenValidators = true;

            jwtOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtValidIssuer,
                ValidAudience = jwtValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecurityKey!))
            };
        });
        
        var frontEndAudience = Environment.GetEnvironmentVariable("BASE_FRONTEND_URL");
        
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(frontEndAudience!);
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });

        return services;
    }
}