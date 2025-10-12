namespace TwitchChat.Domain.Aggregates;

using Interfaces;
using TwitchChat.Domain.Events;
using TwitchChat.Shared.Aggregates;

public class ChatUser : BaseAggregateRoot, IChatUserRoot
{
  private string _streamSessionId;
  private string _twitchUserId;
  private int _subcribeCount;
  private int _totalSubcribeMoney;

  public string StreamSessionId { get { return _streamSessionId; } }
  public string TwitchUserId { get { return _twitchUserId; } }
  public int SubscribeCount { get { return _subcribeCount; } }
  public long TotalSubcsribeMoney { get { return _totalSubcribeMoney; } }

  /// <inheritdoc/>
  public void HandleSubscription()
  {
    ArgumentNullException.ThrowIfNullOrEmpty(StreamSessionId, nameof(StreamSessionId));
    ArgumentNullException.ThrowIfNullOrEmpty(TwitchUserId, nameof(TwitchUserId));

    if (_subcribeCount == 0)
    {
      // New Subscriber
      this.DomainEvents.Append(new NewSubscriberEvent()
      {
        LiveStreamSessionId = StreamSessionId,
        TwitchUserId = TwitchUserId,
      });
    }

    this.DomainEvents.Append(new ResubscribeEvent()
    {
      LiveStreamSessionId = StreamSessionId,
      TwitchUserId = TwitchUserId,
    });
  }
}
