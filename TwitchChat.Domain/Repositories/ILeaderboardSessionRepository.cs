using System;
using TwitchChat.Domain.Aggregates.Interfaces;
using TwitchChat.Domain.Entities;

namespace TwitchChat.Domain.Repositories;

public interface ILeaderboardSessionRepository: IGenericRepository
{
  Task<ILeaderboardSessionRoot> GetCurrentSessionAsync(string liveStreamId, CancellationToken token);
}
