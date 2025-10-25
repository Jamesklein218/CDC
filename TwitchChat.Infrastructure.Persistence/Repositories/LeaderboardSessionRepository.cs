using Microsoft.EntityFrameworkCore;
using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Repositories;
using TwitchChat.Infrastructure.Persistence.SqlServer;

namespace TwitchChat.Infrastructure.Persistence.Repositories;

public class LeaderboardSessionRepository(TwitchChatDbContext dbContext) :
    GenericRepository<LeaderboardSession>(dbContext), ILeaderboardSessionRepository
{
    public async Task<LeaderboardSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token)
    {
        var currentSession = await DbSet
            .Where(x => x.LivestreamId == twitchLiveStreamId && x.EndAt > DateTimeOffset.Now)
            .FirstOrDefaultAsync(token);

        if (currentSession != null)
        {
            throw new Exception("There exist a current leaderboard session.");
        }

        var newLeaderboardSession = new LeaderboardSession
        {
            LivestreamId = twitchLiveStreamId,
            ContentToSpam = string.Empty,
            StartAt = DateTimeOffset.Now,
            EndAt = DateTimeOffset.Now
        };

        await DbSet.AddAsync(newLeaderboardSession, token);

        return newLeaderboardSession;
    }

    public async Task<ChatUserLeaderboardSessionRoot?> GetChatUserLeaderboardSessionAsync(string liveStreamId,
        CancellationToken token)
    {
        var userSessionScoreList = await DbContext.ChatUserSessionScores
            .Include(score => score.LeaderboardSession)
            .Where(score => score.LeaderboardSession.EndAt > DateTimeOffset.Now)
            .Include(score => score.User)
            .ToListAsync(token);

        if (userSessionScoreList.Count == 0)
        {
            return null;
        }

        return new ChatUserLeaderboardSessionRoot()
        {
            UserScoreInfo = userSessionScoreList.FirstOrDefault(),
        };
    }
}