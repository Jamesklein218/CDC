namespace TwitchChat.Shared.Messages;

public interface IMessageProducer<TMessage>
{
  /// <summary>
  /// Take a list of events and publish them.
  /// </summary>
  /// <param name="events"></param>
  /// <param name="token"></param>
  /// <returns></returns>
  Task ProducerMessageAsync(IEnumerable<TMessage> events, CancellationToken token);
}
