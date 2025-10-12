using TwitchChat.Domain.Events;

namespace TwitchChat.Domain.Aggregates.Interfaces;

public interface IChatUserRoot
{
  string TwichStreamId { get; }
  string TwitchUserId { get; }
  int SubscribeCount { get; }
  long TotalSubcsribeMoney { get; }

  /// <summary>
  /// 
  /// </summary>
  void HandleSubscription(IEnumerable<IEvent> events);
}
