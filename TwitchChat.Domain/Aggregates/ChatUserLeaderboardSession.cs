using TwitchChat.Domain.Aggregates.Interfaces;
using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Events;
using TwitchChat.Domain.Model;
using TwitchChat.Shared.Aggregates;

namespace TwitchChat.Domain.Aggregates;

public class ChatUserLeaderboardSession: BaseAggregateRoot, IChatUserLeaderboardSessionRoot
{
  public ChatUser Chatuser { get; }
  public LeaderboardSession LeaderboardSession { get; }
  public int Score { get; set; }
  public bool IsSessionFinished { get
    {
      return DateTimeOffset.Compare(LeaderboardSession.EndAt, DateTimeOffset.UtcNow) < 0;
    }
  }

  /// <inheritdoc/>
  public async Task AddSpamEntryAsync(SpamEntry spamEntry, CancellationToken token)
  {
    ArgumentNullException.ThrowIfNull(spamEntry, nameof(spamEntry));

    var isSpamMessage = string.Compare(
      spamEntry.Content.Trim(),
      LeaderboardSession.ContentToSpam,
      StringComparison.InvariantCultureIgnoreCase) == 0;

    if (isSpamMessage)
    {
      this.Score++;
      this.DomainEvents.Append(new SpamMessageEvent());
    }
  }
}
