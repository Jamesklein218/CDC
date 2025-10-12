using System;
using TwitchChat.Domain.Aggregates.Interfaces;

namespace TwitchChat.Domain.Repositories;

public interface IUserRepository: IGenericRepository
{
  public Task<IChatUserRoot> GetOrCreateNewAsync(string UserName, CancellationToken token);
}
