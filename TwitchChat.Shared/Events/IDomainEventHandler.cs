namespace TwitchChat.Shared.Events;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent: IDomainEvent
{
  Task HandleAsync(TDomainEvent eventObj, CancellationToken token);
  Task BulkHandleAsync(IEnumerable<TDomainEvent> events, CancellationToken token);
}
