using System.Text.Json.Serialization;
using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class ResubscribeEvent : IDomainEvent
{
  public string Name => "subscriber.resubscribe";

  [JsonPropertyName(nameof(LiveStreamSessionId))]
  public string LiveStreamSessionId { get; set; }

  [JsonPropertyName(nameof(TwitchStreamId))]
  public string TwitchStreamId { get; set; }

  [JsonPropertyName(nameof(TwitchUserId))]
  public string TwitchUserId { get; set; }
}
