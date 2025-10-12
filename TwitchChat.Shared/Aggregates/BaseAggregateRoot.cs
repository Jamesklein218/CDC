using TwitchChat.Shared.Events;

namespace TwitchChat.Shared.Aggregates;

public class BaseAggregateRoot: IAggregateRoot
{
  private IEnumerable<IEvent> _domainEvents;
  public IEnumerable<IEvent> DomainEvents {
    get
    {
      return _domainEvents;
    }
    init
    {
      _domainEvents = new List<IEvent>();
    }
  }
}
