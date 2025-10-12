using System;
using TwitchChat.Domain.Events;
using TwitchChat.Domain.Values;

namespace TwitchChat.Domain.Aggregates.Interfaces;

public interface ILeaderboardSessionRoot
{
  string LivestreamId { get; }
  bool IsFinished { get; }

  /// <summary>
  /// 
  /// </summary>
  Task AddSpamEntryAsync(SpamEntry entry, IEnumerable<IEvent> events, CancellationToken token);
}
