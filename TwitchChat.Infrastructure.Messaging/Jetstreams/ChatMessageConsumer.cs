using Microsoft.Extensions.DependencyInjection;
using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;
using NATS.Net;
using TwitchChat.Domain.Events;
using TwitchChat.Shared.Events;
using TwitchChat.Shared.Messages;

namespace TwitchChat.Infrastructure.Messaging.Jetstreams;

public class ChatMessageConsumer(
  IConnectionFactory connectionFactory,
  IServiceProvider serviceProvider
) : IMessageConsumer<ChatMessageEvent>
{
  private INatsClient JsClient { get; set; }
  private INatsJSContext JsContext { get; set; }
  private INatsJSConsumer JsConsumer { get; set; }
  private CancellationTokenSource Cts { get; set; }
  
  public async Task StartConsumeAsync(CancellationToken token)
  {
    // Create a client
    JsClient = connectionFactory.CreateClient();
    JsContext = JsClient.CreateJetStreamContext();
    
    // Create a durable stream
    JsConsumer = await JsContext.CreateOrUpdateConsumerAsync(
      stream: "twitch.chat", 
      config: new ConsumerConfig("twitch.chat.durable"),
      cancellationToken: token);

    // Create a global
    Cts = new CancellationTokenSource();
    
    // Create a thread to process the consumer
    await Task.Run(async () =>
    {
      // https://nats-io.github.io/nats.net/documentation/jetstream/consume.html#consume-method
      // We utilize pull-based consumer for performance reason, which reduces high contention of messages.
      await foreach (NatsJSMsg<ChatMessageEvent> msg in JsConsumer
                       .ConsumeAsync<ChatMessageEvent>()
                       .WithCancellation(Cts.Token))
      {
        // Process the method
        if (msg.Data != null && await HandleMessageAsync(msg.Data, Cts.Token))
        {
          await msg.AckAsync(cancellationToken: Cts.Token);
        }
        else
        {
          await msg.NakAsync(cancellationToken: Cts.Token);
        }
      }
    }, Cts.Token);
  }

  public async Task StopConsumeAsync(CancellationToken token)
  {
    await Cts.CancelAsync();
  }

  private async Task<bool> HandleMessageAsync(ChatMessageEvent message, CancellationToken token)
  {
    using var scope = serviceProvider.CreateScope();
    var handler = scope.ServiceProvider.GetRequiredService<IDomainEventHandler<ChatMessageEvent>>();
    try
    {
      await handler.HandleAsync(message, token);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }
}
