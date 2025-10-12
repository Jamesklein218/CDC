using TwitchChat.Domain.Aggregates.Interfaces;
using TwitchChat.Domain.Events;
using TwitchChat.Domain.Values;

namespace TwitchChat.Domain.Aggregates;

public class LeaderboardSession: ILeaderboardSessionRoot
{
  public string LivestreamId { get; }
  public bool IsFinished { get; }

  /// <inheritdoc/>
  public async Task AddSpamEntryAsync(SpamEntry entry, IEnumerable<IEvent> events, CancellationToken token)
  {
    return;
  }
}
