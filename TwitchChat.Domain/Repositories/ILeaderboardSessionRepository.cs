namespace TwitchChat.Domain.Repositories;

using Domain.Aggregates.Interfaces;
using TwitchChat.Domain.Aggregates;

public interface ILeaderboardSessionRepository: IGenericRepository
{
  Task<LeaderboardSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token);
  Task<ILeaderboardSessionRoot> GetCurrentSessionAsync(string liveStreamId, CancellationToken token);
}
