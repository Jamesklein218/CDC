using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class NewLeaderboardEvent : IDomainEvent
{
  public string Name => "leaderboard.new";
}
