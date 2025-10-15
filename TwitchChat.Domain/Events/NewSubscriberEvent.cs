using System.Text.Json.Serialization;
using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class NewSubscriberEvent : IDomainEvent
{
  public string Name => "subscriber.new";

  [JsonPropertyName(nameof(LiveStreamSessionId))]
  public string LiveStreamSessionId { get; set; }

  [JsonPropertyName(nameof(TwitchUserId))]
  public string TwitchUserId { get; set; }
}
