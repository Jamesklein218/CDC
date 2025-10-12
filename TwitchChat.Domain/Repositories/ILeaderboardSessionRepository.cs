namespace TwitchChat.Domain.Repositories;

using CDC.Contract;
using Domain.Aggregates.Interfaces;
using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;

public interface ILeaderboardSessionRepository: IGenericRepository, ICdcChangeSource<ChatUserLeaderboardSession>
{
  Task<LeaderboardSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token);
  Task<IChatUserLeaderboardSessionRoot> GetChatUserLeaderboardSessionAsync(string liveStreamId, CancellationToken token);
}
