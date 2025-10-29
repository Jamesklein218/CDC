using Microsoft.EntityFrameworkCore;
using TwitchChat.Domain.Entities;

namespace TwitchChat.Infrastructure.Persistence;

public class TwitchChatDbContext : DbContext
{
    public DbSet<ChatUser> ChatUsers { get; set; }
    public DbSet<ChatMessage>  ChatMessages { get; set; }
    public DbSet<LeaderboardSession>  LeaderboardSessions { get; set; }
    public DbSet<LiveStreamSession> LiveStreamSessions { get; set; }
    public DbSet<ChatUserSessionScore> ChatUserSessionScores { get; set; }
    
    public TwitchChatDbContext(DbContextOptions<TwitchChatDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ChatUser -- N -- ChatUserSessionScore -- N -- LeaderboardSession
        // PK: ChatUserSessionScore
        modelBuilder.Entity<ChatUserSessionScore>()
            .HasKey(sessionScore => new
            {
                sessionScore.UserId,
                sessionScore.LeaderboardSessionId
            });

        // FK: ChatUserSessionScore -> User
        modelBuilder.Entity<ChatUserSessionScore>()
            .HasOne(cus => cus.User)
            .WithMany(cu => cu.Sessions)
            .HasForeignKey(cus => cus.UserId);

        // FK: ChatUserSessionScore -> LeaderboardSession 
        modelBuilder.Entity<ChatUserSessionScore>()
            .HasOne(cus => cus.LeaderboardSession)
            .WithMany(ls => ls.Participants)
            .HasForeignKey(cus => cus.LeaderboardSessionId);
    }
}