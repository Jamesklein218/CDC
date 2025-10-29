using Microsoft.EntityFrameworkCore;
using TwitchChat.Shared.Repositories;

namespace TwitchChat.Infrastructure.Persistence;

public class GenericRepository<T>(TwitchChatDbContext dbContext)
: IGenericRepository<T> where T : class
{
    protected DbSet<T> DbSet
    {
        get => DbContext.Set<T>();
    }

    protected readonly TwitchChatDbContext DbContext = dbContext;

    public async Task SaveChangeAsync(CancellationToken token)
    {
        await DbContext.SaveChangesAsync(token);
    }
    
    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken token)
    {
        return await DbSet.ToListAsync(token);
    }
}