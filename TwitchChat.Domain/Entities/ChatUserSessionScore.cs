using System.ComponentModel.DataAnnotations;

namespace TwitchChat.Domain.Entities;

public class ChatUserSessionScore
{
    public Guid LeaderboardSessionId { get; set; }
    public string UserId { get; set; }
    public int Score { get; set; }
    public ChatUser User { get; set; }
    public LeaderboardSession LeaderboardSession { get; set; }
}