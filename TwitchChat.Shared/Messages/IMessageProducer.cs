namespace TwitchChat.Shared.Messages;

public interface IMessageProducer<TMessage>
{
  /// <summary>
  /// Take a list of events and publish them.
  /// </summary>
  /// <param name="messages"></param>
  /// <param name="token"></param>
  /// <returns></returns>
  Task ProduceMessageAsync(IEnumerable<TMessage> messages, CancellationToken token);
}
