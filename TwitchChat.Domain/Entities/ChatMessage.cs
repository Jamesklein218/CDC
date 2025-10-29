using System.ComponentModel.DataAnnotations;
using TwitchChat.Domain.Model;

namespace TwitchChat.Domain.Entities;

public class ChatMessage
{
  [Key]
  public string Id {  get; set; }
  public ChatMessageType MessageType  {  get; set; }
  public string Content  { get; set; }
  public string TwitchUserId  { get; set; }
  public string TwitchLivestreamId  { get; set; }
}
