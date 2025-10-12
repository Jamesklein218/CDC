using CDC.Contract;
using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Aggregates.Interfaces;

namespace TwitchChat.Domain.Repositories;

public interface IUserRepository: IGenericRepository, ICdcChangeSource<ChatUser>
{
  public Task<IChatUserRoot> GetOrCreateNewAsync(string UserName, CancellationToken token);
}
