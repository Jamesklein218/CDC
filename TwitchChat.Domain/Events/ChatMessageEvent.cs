using TwitchChat.Domain.Entities;
using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Events;

public class ChatMessageEvent: IDomainEvent
{
  public string Name => "twitch.chat.message";

  public ChatMessage ChatMessage { get; set; }
}
