using System.Text;
using System.Text.Json;
using NATS.Client;
using NATS.Client.JetStream;
using Polly;
using Polly.Retry;
using TwitchChat.Shared.Events;

namespace TwitchChat.Infrastructure.Messaging.Jetstreams;

class JetstreamEventPublisher(IJetStream jetStream) : IEventPublisher
{
  private static ResiliencePipeline Retrier => new ResiliencePipelineBuilder()
    .AddRetry(new RetryStrategyOptions()
    {
      BackoffType = DelayBackoffType.Exponential,
      Delay = TimeSpan.FromMilliseconds(200),
      MaxRetryAttempts = 3,
      UseJitter = true,
      ShouldHandle = new PredicateBuilder()
        .Handle<IOException>()
        .Handle<NATSConnectionException>(),
    })
    .Build();

  /// <inheritdoc/>
  public async Task PublishAsync(IEnumerable<IEvent> events, CancellationToken token)
  {
    var tasks = events.Select((eventObj) => this.PublishOneMessageAsync(eventObj, token));
    await Retrier.ExecuteAsync(async ct => Task.WhenAll(tasks), token);
  }
  private async Task PublishOneMessageAsync(IEvent eventObj, CancellationToken token)
  {
    token.ThrowIfCancellationRequested();
    var eventObjStr = JsonSerializer.Serialize<IEvent>(eventObj);
    var bytes = Encoding.UTF8.GetBytes(eventObjStr);

    var publishAck = await jetStream.PublishAsync(eventObj.Name, data: bytes);

    if (publishAck.HasError)
    {
      throw new IOException();
    }
  }
}
