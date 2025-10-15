namespace TwitchChat.Shared.Events;

public interface IDomainEventHandlerFactory
{
  IEnumerable<IDomainEventHandler<IDomainEvent>> GetHandlers(string keyPattern);
}
