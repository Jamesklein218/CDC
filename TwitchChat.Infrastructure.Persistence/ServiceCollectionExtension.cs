using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitchChat.Domain.Repositories;
using TwitchChat.Infrastructure.Persistence.Repositories;

namespace TwitchChat.Infrastructure.Persistence;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSqlServerRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Connection string"
                                                                      + "'DefaultConnection' not found.");

        var connectionPoolSizeText = configuration["DbPoolSize"]
                                 ?? throw new InvalidOperationException("DB Pool size not found.");
        if (!int.TryParse(connectionPoolSizeText, out var poolSize))
        {
            throw new InvalidOperationException("Pool size is not an integer.");
        }

        services.AddDbContextPool<TwitchChatDbContext>(options =>
            options.UseSqlServer(connectionString,
                // Add TwitchChat.Migrations as a migration strategy
                x => x.MigrationsAssembly("TwitchChat.Migrations")),
            poolSize);

        services
            .AddScoped<ILeaderboardSessionRepository, LeaderboardSessionRepository>()
            .AddScoped<ILivestreamSessionRepository, LivestreamSessionRepository>()
            .AddScoped<ILeaderboardSessionRepository, LeaderboardSessionRepository>()
            .AddScoped<IUserRepository, UserRepository>();
            
        return services;
    }
}
