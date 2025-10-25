namespace TwitchChat.Shared.Messages;

public interface IMessageConsumer<TMessage>
{
  /// <summary>
  /// Start consuming the messages
  /// </summary>
  /// <param name="token"></param>
  /// <returns></returns>
  Task StartConsumeAsync();

  /// <summary>
  /// Start consuming the messaign
  /// </summary>
  /// <param name="token"></param>
  /// <returns></returns>
  Task StopConsumeAsync();
}
