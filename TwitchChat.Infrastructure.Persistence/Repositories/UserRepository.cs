using Microsoft.EntityFrameworkCore;
using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Repositories;
using TwitchChat.Infrastructure.Persistence.SqlServer;

namespace TwitchChat.Infrastructure.Persistence.Repositories;

public class UserRepository(TwitchChatDbContext dbContext): GenericRepository<ChatUser>(dbContext), IUserRepository
{
    public async Task<ChatUserRoot> GetOrCreateNewAsync(string UserName, CancellationToken token)
    {
        var newUser = new ChatUser()
        {
            TwitchUserId = UserName,
            UserName =  UserName,
            SubscribeCount = 0,
            TotalSubscribeMoney = 0,
        };

        await DbSet.AddAsync(newUser, token);
        
        return new ChatUserRoot
        {
            User = newUser
        };
    }
}