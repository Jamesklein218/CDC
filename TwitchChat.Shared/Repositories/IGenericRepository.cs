namespace TwitchChat.Shared.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
  Task SaveChangeAsync(CancellationToken token);
  Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token);
}
