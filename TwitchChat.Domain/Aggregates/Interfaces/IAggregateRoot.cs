using TwitchChat.Domain.Events;

namespace TwitchChat.Domain.Aggregates.Interfaces;

/// <summary>
/// Marker interface
/// </summary>
public interface IAggregateRoot
{
  /// <summary>
  /// Get all domain events of the aggregate roots
  /// </summary>
  IEnumerable<IEvent> DomainEvents { get; }
}
