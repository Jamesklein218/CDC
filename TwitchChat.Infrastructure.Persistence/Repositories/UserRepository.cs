using Microsoft.EntityFrameworkCore;
using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Repositories;

namespace TwitchChat.Infrastructure.Persistence.Repositories;

public class UserRepository(TwitchChatDbContext dbContext): GenericRepository<ChatUser>(dbContext), IUserRepository
{
    public async Task<ChatUserRoot> GetOrCreateNewAsync(string userName, CancellationToken token)
    {
        var existingUser = await DbSet
            .FirstOrDefaultAsync(u => u.TwitchUserId == userName, token);

        if (existingUser != null)
        {
            return new ChatUserRoot
            {
                User = existingUser
            };
        }

        var newUser = new ChatUser
        {
            TwitchUserId = userName,
            UserName = userName,
            SubscribeCount = 0,
            TotalSubscribeMoney = 0
        };

        await DbSet.AddAsync(newUser, token);
        await DbContext.SaveChangesAsync(token); // persist new record

        return new ChatUserRoot
        {
            User = newUser
        };
    }
}