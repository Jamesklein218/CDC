using CDC.Contract;
using TwitchChat.Domain.Aggregates;

namespace TwitchChat.Domain.Repositories;

public interface ILivestreamSessionRepository: IGenericRepository, ICdcChangeSource<LiveStreamSession>
{
  Task<LiveStreamSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token);
}
