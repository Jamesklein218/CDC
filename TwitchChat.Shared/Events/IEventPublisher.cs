using System;

namespace TwitchChat.Shared.Events;

public interface IEventPublisher
{
  /// <summary>
  /// Take a list of events and publish them.
  /// </summary>
  /// <param name="events"></param>
  /// <param name="token"></param>
  /// <returns></returns>
  Task PublishAsync(IEnumerable<IEvent> events, CancellationToken token);
}
