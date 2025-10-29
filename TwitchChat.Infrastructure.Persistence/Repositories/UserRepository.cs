using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Repositories;

namespace TwitchChat.Infrastructure.Persistence.Repositories;

public class UserRepository(TwitchChatDbContext dbContext): GenericRepository<ChatUser>(dbContext), IUserRepository
{
    public async Task<ChatUserRoot> GetOrCreateNewAsync(string userName, CancellationToken token)
    {
        var newUser = new ChatUser()
        {
            TwitchUserId = userName,
            UserName =  userName,
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