namespace TwitchChat.Domain.Model;

public class SpamEntry
{
  public string UserId { get; set; }
  public string Content { get; set; }
  public DateTimeOffset TimeStamp { get; set; }
}
