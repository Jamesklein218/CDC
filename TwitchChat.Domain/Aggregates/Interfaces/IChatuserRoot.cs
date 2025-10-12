using System;
using System.Numerics;
using TwitchChat.Domain.Events;

namespace TwitchChat.Domain.Aggregates.Interfaces;

public interface IChatUserRoot
{
  string UserName { get; }
  int SubscribeCount { get; }
  long TotalSubcsribeMoney { get; }

  void HandleSubscription(IEnumerable<IEvent> events);
}
