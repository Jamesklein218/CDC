using System.Text.Json.Serialization;

namespace TwitchChat.Shared.Events;

public interface IEvent
{
  [JsonIgnore]
  string Name { get; }
}
