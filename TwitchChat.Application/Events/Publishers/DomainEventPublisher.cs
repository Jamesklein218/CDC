using TwitchChat.Shared.Events;
using TwitchChat.Shared.Messages;

namespace TwitchChat.Application.Events.Publishers;

public class DomainEventPublisher: IDomainEventPublisher
{
    public Task PublishAsync(IEnumerable<IDomainEvent> events, CancellationToken token)
    {
        return Task.CompletedTask;
    }
}