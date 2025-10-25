using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Events;
using TwitchChat.Domain.Model;
using TwitchChat.Shared.Aggregates;

namespace TwitchChat.Domain.Aggregates;

public class ChatUserLeaderboardSessionRoot: BaseAggregateRoot
{
  public ChatUserSessionScore UserScoreInfo { get; set; }
  public bool IsSessionFinished => DateTimeOffset
    .Compare(UserScoreInfo.LeaderboardSession.EndAt,DateTimeOffset.UtcNow) < 0;

  public void AddSpamEntry(SpamEntry spamEntry)
  {
    ArgumentNullException.ThrowIfNull(spamEntry, nameof(spamEntry));

    var isSpamMessage = string.Compare(
      spamEntry.Content.Trim(),
      UserScoreInfo.LeaderboardSession.ContentToSpam,
      StringComparison.InvariantCultureIgnoreCase) == 0;

    if (isSpamMessage)
    {
      UserScoreInfo.Score++;
      DomainEvents = DomainEvents.Append(new SpamMessageEvent());
    }
  }
}
