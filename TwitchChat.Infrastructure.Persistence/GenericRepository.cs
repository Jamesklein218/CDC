using Microsoft.EntityFrameworkCore;
using TwitchChat.Shared.Repositories;

namespace TwitchChat.Infrastructure.Persistence.SqlServer;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected DbSet<T> DbSet
    {
        get => DbContext.Set<T>();
    }
    
    protected readonly TwitchChatDbContext DbContext; 

    public GenericRepository(TwitchChatDbContext context)
    {
        DbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task SaveChangeAsync(CancellationToken token)
    {
        await DbContext.SaveChangesAsync(token);
    }
    
    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken token)
    {
        return await DbSet.ToListAsync(token);
    }
}