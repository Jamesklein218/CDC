namespace TwitchChat.Domain.Repositories;

using Aggregates;
using Entities;
using TwitchChat.Shared.Repositories;

public interface ILeaderboardSessionRepository: IGenericRepository<LeaderboardSession>
{
  Task<LeaderboardSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token);
  Task<ChatUserLeaderboardSessionRoot?> GetChatUserLeaderboardSessionAsync(string liveStreamId, CancellationToken token);
}
