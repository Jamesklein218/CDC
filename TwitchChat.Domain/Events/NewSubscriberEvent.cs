namespace TwitchChat.Domain.Events;

public class NewSubscriberEvent: IEvent
{
  public string LiveStreamSessionId { get; set; }
  public string TwitchUserId { get; set; }
}
