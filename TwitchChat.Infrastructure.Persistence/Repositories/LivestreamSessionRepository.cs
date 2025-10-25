using Microsoft.EntityFrameworkCore;
using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Repositories;
using TwitchChat.Infrastructure.Persistence.SqlServer;

namespace TwitchChat.Infrastructure.Persistence.Repositories;

public class LivestreamSessionRepository(TwitchChatDbContext dbContext):
    GenericRepository<LiveStreamSession>(dbContext), ILivestreamSessionRepository
{
    public async Task<LiveStreamSession> CreateNewAsync(string twitchLiveStreamId, CancellationToken token)
    {
        var newLivestreamSession = new LiveStreamSession()
        {
            TwitchLivestreamId = twitchLiveStreamId,
        };

        await DbSet.AddAsync(newLivestreamSession, token);
        
        return newLivestreamSession;
    }
}