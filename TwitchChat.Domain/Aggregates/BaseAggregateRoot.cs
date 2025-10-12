using System;
using TwitchChat.Domain.Aggregates.Interfaces;
using TwitchChat.Domain.Events;

namespace TwitchChat.Domain.Aggregates;

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
