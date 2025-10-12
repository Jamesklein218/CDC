using System.Text.Json.Serialization;
using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class ResubscribeEvent : IEvent
{
  public string Name => "suscriber.resubscribe";

  [JsonPropertyName(nameof(LiveStreamSessionId))]
  public string LiveStreamSessionId { get; set; }

  [JsonPropertyName(nameof(TwitchStreamId))]
  public string TwitchStreamId { get; set; }

  [JsonPropertyName(nameof(TwitchUserId))]
  public string TwitchUserId { get; set; }
}
