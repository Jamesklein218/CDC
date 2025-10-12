namespace TwitchChat.Domain.Repositories;

public interface IGenericRepository
{
  Task SaveChangeAsync(CancellationToken token);
}
