namespace TwitchChat.Domain.Entities;

public class LeaderboardSession
{
  public string LivestreamId { get; }
  public string ContentToSpam { get; }
  public DateTimeOffset StartAt { get; }
  public DateTimeOffset EndAt { get; }
}
