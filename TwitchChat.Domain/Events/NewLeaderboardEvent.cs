using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class NewLeaderboardEvent : IEvent
{
  public string Name => "leaderboard.new";
}
