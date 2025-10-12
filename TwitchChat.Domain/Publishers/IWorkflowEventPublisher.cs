using TwitchChat.Domain.Events;

namespace TwitchChat.Domain.Publishers;

public interface IWorkflowEventPublisher
{
  Task PublishAsync(IEnumerable<IEvent> events, CancellationToken token);
}
