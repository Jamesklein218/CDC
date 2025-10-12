namespace TwitchChat.Domain.Aggregates.Interfaces;

using Events;
using Values;

public interface ILeaderboardSessionRoot
{
  string LivestreamId { get; }
  bool IsFinished { get; }

  /// <summary>
  /// 
  /// </summary>
  Task AddSpamEntryAsync(SpamEntry entry, IEnumerable<IEvent> events, CancellationToken token);
}
