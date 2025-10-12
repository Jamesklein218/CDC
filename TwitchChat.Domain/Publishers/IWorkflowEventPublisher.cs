using TwitchChat.Shared.Events;

namespace TwitchChat.Domain.Publishers;

public interface IWorkflowEventPublisher
{
  Task PublishAsync(IEnumerable<IEvent> events, CancellationToken token);
}
