using Microsoft.Extensions.Options;
using NATS.Client;
using NATS.Client.JetStream;
using TwitchChat.Infrastructure.Messaging.Options;
using TwitchChat.Shared.Events;

using IAppMessageConsumer = TwitchChat.Shared.Messages.IMessageConsumer;

namespace TwitchChat.Infrastructure.Messaging.Jetstreams;

public class TwitchChatEventConsumer(
  IOptions<NatsOptions> natServerOptions,
  IEnumerable<IOptions<JetStreamOptions>> streamOptions,
  IServiceProvider serviceProvider
) : IAppMessageConsumer
{
  private IConnection connection { get; set; }
  private NATS.Client.Options natsOptions { get; set; }
  private IStreamContext streamContext { get; set; }
  private StreamInfo streamInfo { get; set; }

  public async Task StartConsumeAsync(CancellationToken token)
  {
    natsOptions = ConnectionFactory.GetDefaultOptions(natServerOptions.Value.Url);
    var connectionFactory = new ConnectionFactory();

    connection = connectionFactory.CreateConnection(natsOptions);

    var streamsContexes = streamOptions
      .Select(opt => connection.CreateJetStreamContext(opt.Value));
  }

  public async Task StopConsumeAsync(CancellationToken token)
  {
    connection.Dispose();
  }

  public async Task ConsumeAsync(IDomainEvent singleEvent, CancellationToken token)
  {
  }

  public Task BatchConsumeAsync(IEnumerable<IDomainEvent> events, CancellationToken token)
  {
    throw new NotImplementedException();
  }
}
