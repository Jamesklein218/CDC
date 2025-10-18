using System.Security.Cryptography.X509Certificates;
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

  private INatsClient jsClient { get; set; }
  private INatsJSContext context { get; set; }
  private string Name { get; set; }

  public BaseJetstreamProducer(IOptions<NatsOpts> options, String name = null)
  {
    if (name == null)
    {
      throw new Exception("Invalid stream name");
    }

    // Should use factory
    jsClient = new NatsClient(options.Value, System.Threading.Channels.BoundedChannelFullMode.Wait);
    context = jsClient.CreateJetStreamContext();

    // Create new 
    CreateNewStream(name, name + ".*").GetAwaiter().GetResult();
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
    await context.CreateStreamAsync(new StreamConfig()
    {
      Name = name,
      Subjects = [subject]
    }, token);
  }

  /// <inheritdoc/>
  public virtual async Task PublishAsync(IEnumerable<(string suject, object data)> events, CancellationToken token)
  {
    var tasks = events.Select((eventObj) => PublishOneMessageAsync(eventObj, token));
    await Retrier.ExecuteAsync(async ct => Task.WhenAll(tasks), token);
  }
  public virtual async Task PublishOneMessageAsync((string suject, object data) eventObj, CancellationToken token)
  {
    token.ThrowIfCancellationRequested();
    await jsClient.PublishAsync(eventObj.suject, eventObj.data, cancellationToken: token);
  }
}
