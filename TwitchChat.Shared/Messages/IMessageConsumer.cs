namespace TwitchChat.Shared.Messages;

public interface IMessageConsumer
{
  /// <summary>
  /// Start consuming the messages
  /// </summary>
  /// <param name="token"></param>
  /// <returns></returns>
  Task StartConsumeAsync(CancellationToken token);

  /// <summary>
  /// Start consuming the messaign
  /// </summary>
  /// <param name="token"></param>
  /// <returns></returns>
  Task StopConsumeAsync(CancellationToken token);
}
