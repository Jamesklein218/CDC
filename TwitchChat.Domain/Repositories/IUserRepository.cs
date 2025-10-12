using System;
using TwitchChat.Domain.Aggregates.Interfaces;

namespace TwitchChat.Domain.Repositories;

public interface IUserRepository: IGenericRepository
{
  public Task<IChatUserRoot?> GetUserAsync(string UserName, CancellationToken token);
}
