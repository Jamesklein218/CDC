using Microsoft.EntityFrameworkCore;
using TwitchChat.Infrastructure.Persistence.SqlServer;

namespace TwitchChat.Infrastructure.Persistence;

public class DbContextFactory: IDbContextFactory<TwitchChatDbContext>
{
    private readonly IDbContextFactory<TwitchChatDbContext> _pooledFactory;

    public DbContextFactory(IDbContextFactory<TwitchChatDbContext> pooledFactory)
    {
        _pooledFactory = pooledFactory;
    }

    public TwitchChatDbContext CreateDbContext()
    {
        var context = _pooledFactory.CreateDbContext();
        return context;
    }
}