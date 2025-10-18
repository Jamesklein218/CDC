using Microsoft.Extensions.Options;
using TwitchChat.Infrastructure.Messaging.Options;
using TwitchChat.Shared.Events;

using IAppMessageConsumer = TwitchChat.Shared.Messages.IMessageConsumer;

namespace TwitchChat.Infrastructure.Messaging.Jetstreams;

public class TwitchChatEventConsumer(
  IOptions<NatsOptions> natServerOptions,
  IServiceProvider serviceProvider
) : IAppMessageConsumer
{
  public async Task StartConsumeAsync(CancellationToken token)
  {
  }

  public async Task StopConsumeAsync(CancellationToken token)
  {
  }

  public async Task ConsumeAsync(IDomainEvent singleEvent, CancellationToken token)
  {
  }

  public Task BatchConsumeAsync(IEnumerable<IDomainEvent> events, CancellationToken token)
  {
    throw new NotImplementedException();
  }
}
