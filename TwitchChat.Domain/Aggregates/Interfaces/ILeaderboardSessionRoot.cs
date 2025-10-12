namespace TwitchChat.Domain.Aggregates.Interfaces;

using Events;
using TwitchChat.Domain.Entities;
using Values;

public interface IChatUserLeaderboardSessionRoot: IAggregateRoot
{
  ChatUser Chatuser { get; }
  LeaderboardSession LeaderboardSession { get; }
  int Score { get; set; }
  bool IsSessionFinished { get; }

  /// <summary>
  /// When a `SpamEvent` is detected, check if the leaderboard session is finished, if not, stored in the KV Store.
  /// </summary>
  Task AddSpamEntryAsync(SpamEntry entry, CancellationToken token);
}
