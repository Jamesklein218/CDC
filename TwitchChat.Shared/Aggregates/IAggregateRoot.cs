using TwitchChat.Shared.Events;

namespace TwitchChat.Shared.Aggregates;

/// <summary>
/// Marker interface
/// </summary>
public interface IAggregateRoot
{
  /// <summary>
  /// Get all domain events of the aggregate roots
  /// </summary>
  IEnumerable<IDomainEvent> DomainEvents { get; }
}
