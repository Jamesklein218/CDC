namespace TwitchChat.Domain.Aggregates;

using System;
using System.Numerics;
using Interfaces;
using TwitchChat.Domain.Events;

public class ChatUser : IChatUserRoot
{
  private readonly string _twitchStreamId;
  private readonly string _twitchUserId;
  private readonly int _subcribeCount;
  private readonly int _totalSubcribeMoney;

  public string TwichStreamId { get { return _twitchStreamId; } }
  public string TwitchUserId { get { return _twitchUserId; } }
  public int SubscribeCount { get { return _subcribeCount; } }
  public long TotalSubcsribeMoney { get { return _totalSubcribeMoney; } }

  /// <inheritdoc/>
  public void HandleSubscription(IEnumerable<IEvent> events)
  {
  }
}
