using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;
using TwitchChat.Shared.Repositories;

namespace TwitchChat.Domain.Repositories;

public interface IUserRepository: IGenericRepository<ChatUser>
{
  public Task<ChatUserRoot> GetOrCreateNewAsync(string UserName, CancellationToken token);
}
