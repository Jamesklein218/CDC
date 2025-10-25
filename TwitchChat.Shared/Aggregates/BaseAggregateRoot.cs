using TwitchChat.Shared.Events;

namespace TwitchChat.Shared.Aggregates;

public class BaseAggregateRoot: IAggregateRoot
{
  public IEnumerable<IDomainEvent> DomainEvents { get; set; } = new List<IDomainEvent>();
}
