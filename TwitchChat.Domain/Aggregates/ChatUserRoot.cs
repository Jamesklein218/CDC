using TwitchChat.Domain.Entities;
using TwitchChat.Shared.Aggregates;

namespace TwitchChat.Domain.Aggregates;

using Events;

public class ChatUserRoot : BaseAggregateRoot
{
  private string _streamSessionId;
  private string _twitchUserId;
  private int _subcribeCount;
  private int _totalSubcribeMoney;

  public ChatUser User { get; set; }

  public void HandleSubscription(string streamSessionId)
  {
    ArgumentNullException.ThrowIfNullOrEmpty(User.TwitchUserId, nameof(User.TwitchUserId));

    if (_subcribeCount == 0)
    {
      // New Subscriber
      DomainEvents = DomainEvents.Append(new NewSubscriberEvent()
      {
        LiveStreamSessionId = streamSessionId,
        TwitchUserId = User.TwitchUserId,
      });
    }

    DomainEvents = DomainEvents.Append(new ResubscribeEvent()
    {
      LiveStreamSessionId = streamSessionId,
      TwitchUserId = User.TwitchUserId,
    });
  }
}
