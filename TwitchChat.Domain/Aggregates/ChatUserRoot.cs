namespace TwitchChat.Domain.Aggregates;

using System;
using System.Numerics;
using Interfaces;
using TwitchChat.Domain.Events;

public class ChatUserRoot: IChatUserRoot
{
  private readonly string _username;
  private readonly int _subcribeCount;
  private readonly int _totalSubcribeMoney;

  public string UserName { get { return _username; } }
  public int SubscribeCount { get { return _subcribeCount; } }
  public long TotalSubcsribeMoney { get { return _totalSubcribeMoney;  } }

  public void HandleSubscription(IEnumerable<IEvent> events)
  {
  }

  public static async Task<IChatUserRoot> CreateNewAsync(string userName, CancellationToken token)
  {
    // TODO
    return new ChatUserRoot();
  }
}
