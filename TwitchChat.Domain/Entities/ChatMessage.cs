using TwitchChat.Domain.Model;

namespace TwitchChat.Domain.Entities;

public class ChatMessage
{
  public string Id;
  public ChatMessageType MessageType;
  public string Content;
  public string TwitchUserId;
  public string TwitchLivestreamId;
}
