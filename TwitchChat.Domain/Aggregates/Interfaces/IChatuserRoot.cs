using TwitchChat.Shared.Aggregates;

namespace TwitchChat.Domain.Aggregates.Interfaces;

public interface IChatUserRoot: IAggregateRoot
{
  string StreamSessionId { get; }
  int SubscribeCount { get; }
  long TotalSubcsribeMoney { get; }

  /// <summary>
  /// New subscriber: store that new subscriber twitchUserId in Store and emit a `NewSubscriberEvent`
  /// Re-subscriber: store that new subscriber twitchUserId in KV Store and emit a `ResubscribeEvent`
  /// </summary>
  void HandleSubscription();
}
