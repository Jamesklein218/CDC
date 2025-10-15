namespace TwitchChat.Shared.Events;

public interface IDomainEventPublisher
{
  /// <summary>
  /// Take a list of events and publish them.
  /// </summary>
  /// <param name="events"></param>
  /// <param name="token"></param>
  /// <returns></returns>
  Task PublishAsync(IEnumerable<IDomainEvent> events, CancellationToken token);
}
