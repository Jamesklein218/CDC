using TwitchChat.Domain.Model;
using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class SpamMessageEvent: SpamEntry, IEvent
{
  public string UserId { get; set; }
  public string Content { get; set; }
  public DateTimeOffset TimeStamp { get; set; }
}
