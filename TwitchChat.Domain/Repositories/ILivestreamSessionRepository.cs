using TwitchChat.Domain.Entities;
using TwitchChat.Shared.Repositories;

namespace TwitchChat.Domain.Repositories;

public interface ILivestreamSessionRepository: IGenericRepository<LiveStreamSession>
{
  Task<LiveStreamSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token);
}
