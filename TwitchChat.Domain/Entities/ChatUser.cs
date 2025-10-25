namespace TwitchChat.Domain.Entities;

public class ChatUser
{
    public string TwitchUserId { get; set; }
    public string UserName { get; set; }
    public int SubscribeCount { get; set; }
    public long TotalSubscribeMoney { get; set; }
    
    public ICollection<ChatUserSessionScore> Sessions { get; set; }}