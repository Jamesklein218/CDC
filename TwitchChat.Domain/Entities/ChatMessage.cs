using System;
using System.Reflection.Metadata;
using TwitchChat.Domain.Values;

namespace TwitchChat.Domain.Entities;

public class ChatMessage
{
  public string Id;
  public ChatMessageType MessageType;
  public string Content;
  public string Username; // PK of user
  public string TwitchLivestreamId;
}
