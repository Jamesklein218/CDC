namespace TwitchChat.Domain.Entities;

public class LeaderboardSession
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string LivestreamId { get; set; }
  public string ContentToSpam { get; set; }
  public DateTimeOffset StartAt { get; set; }
  public DateTimeOffset EndAt { get; set; }
  public ICollection<ChatUserSessionScore> Participants { get; set; }
}
