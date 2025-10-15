using TwitchChat.Shared.Events;

namespace TwitchChat.Shared.Aggregates;

public class BaseAggregateRoot: IAggregateRoot
{
  private IEnumerable<IDomainEvent> _domainEvents;
  public IEnumerable<IDomainEvent> DomainEvents {
    get
    {
      return _domainEvents;
    }
    init
    {
      _domainEvents = new List<IDomainEvent>();
    }
  }
}
