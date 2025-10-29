using Microsoft.Extensions.Options;
using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;
using NATS.Net;
using Polly;
using Polly.Retry;
using TwitchChat.Shared.Events;
using TwitchChat.Shared.Messages;

namespace TwitchChat.Infrastructure.Messaging.Jetstreams;

public class BaseJetstreamProducer<T>: IMessageProducer<T> where T: IDomainEvent
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
    })
    .Build();

  private INatsClient JsClient { get; set; }
  private INatsJSContext JsContext { get; set; }

  public BaseJetstreamProducer(IConnectionFactory connectionFactory, String name = null)
  {
    JsClient = connectionFactory.CreateClient();
    JsContext = JsClient.CreateJetStreamContext();
  }

  /// <summary>
  /// Right way is to create a producer for each type of message. 
  /// But I'm too lazy for that :D
  /// </summary>
  public async Task ProduceMessageAsync(IEnumerable<T> messages, CancellationToken token)
  {
    await PublishAsync(messages.Select(m => (m.Name, (object)m)), token);
  }

  private async Task CreateNewStream(string name, string subject, CancellationToken token = default)
  {
    await JsContext.CreateStreamAsync(new StreamConfig()
    {
      Name = name,
      Subjects = [subject]
    }, token);
  }

  protected virtual async Task PublishAsync(IEnumerable<(string suject, object data)> events, CancellationToken token)
  {
    var tasks = events.Select((eventObj) => PublishOneMessageAsync(eventObj, token));
    await Retrier.ExecuteAsync(async _ => await Task.WhenAll(tasks), token);
  }
  protected virtual async Task PublishOneMessageAsync((string suject, object data) eventObj, CancellationToken token)
  {
    token.ThrowIfCancellationRequested();
    await JsClient.PublishAsync(eventObj.suject, eventObj.data, cancellationToken: token);
  }
}
