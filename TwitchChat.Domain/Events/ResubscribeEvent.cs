using System;
using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class ResubscribeEvent: IEvent
{
  public string LiveStreamSessionId { get; set; }
  public string TwitchStreamId { get; set; }
  public string TwitchUserId { get; set; }
}
