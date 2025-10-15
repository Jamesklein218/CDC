using System.Text.Json.Serialization;

namespace TwitchChat.Shared.Events;

public interface IDomainEvent
{
  [JsonIgnore]
  string Name { get; }
}
