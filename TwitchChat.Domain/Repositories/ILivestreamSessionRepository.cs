using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;

namespace TwitchChat.Domain.Repositories;

public interface ILivestreamSessionRepository: IGenericRepository
{
  Task<LiveStreamSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token);
}
