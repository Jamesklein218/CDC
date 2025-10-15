using System.Text.Json.Serialization;
using TwitchChat.Domain.Model;
using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class SpamMessageEvent: SpamEntry, IDomainEvent
{
  public string Name => "leaderboard.message";

  [JsonPropertyName(nameof(TwitchUserId))]
  public string TwitchUserId { get; set; }

  [JsonPropertyName(nameof(Content))]
  public string Content { get; set; }

  [JsonPropertyName(nameof(TimeStamp))]
  public DateTimeOffset TimeStamp { get; set; }
}
