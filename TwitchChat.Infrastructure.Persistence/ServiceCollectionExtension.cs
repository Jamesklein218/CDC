using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitchChat.Domain.Repositories;
using TwitchChat.Infrastructure.Persistence.Repositories;
using TwitchChat.Infrastructure.Persistence.SqlServer;

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
            options.UseSqlServer(connectionString), poolSize);

        services
            .AddScoped<IDbContextFactory<TwitchChatDbContext>, DbContextFactory>()
            .AddScoped(sp => sp.GetRequiredService<DbContextFactory>().CreateDbContext())
            .AddScoped<ILeaderboardSessionRepository, LeaderboardSessionRepository>()
            .AddScoped<ILivestreamSessionRepository, LivestreamSessionRepository>()
            .AddScoped<ILeaderboardSessionRepository, LeaderboardSessionRepository>()
            .AddScoped<IUserRepository, UserRepository>();
            
        return services;
    }
}
