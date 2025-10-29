using System.ComponentModel.DataAnnotations;

namespace TwitchChat.Domain.Entities;
public class LiveStreamSession
{
  [Key]
  public string TwitchLivestreamId { get; set; }
}
