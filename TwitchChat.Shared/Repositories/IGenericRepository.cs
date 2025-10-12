namespace TwitchChat.Shared.Repositories;

public interface IGenericRepository
{
  Task SaveChangeAsync(CancellationToken token);
}
