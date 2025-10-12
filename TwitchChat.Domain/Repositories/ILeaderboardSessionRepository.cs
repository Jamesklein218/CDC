namespace TwitchChat.Domain.Repositories;

using CDC.Contract;
using Domain.Aggregates.Interfaces;
using TwitchChat.Domain.Aggregates;

public interface ILeaderboardSessionRepository: IGenericRepository, ICdcChangeSource<LeaderboardSession>
{
  Task<LeaderboardSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token);
  Task<ILeaderboardSessionRoot> GetCurrentSessionAsync(string liveStreamId, CancellationToken token);
}
