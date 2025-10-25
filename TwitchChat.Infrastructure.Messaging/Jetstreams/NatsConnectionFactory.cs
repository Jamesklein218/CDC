using Microsoft.Extensions.Options;
using NATS.Client.Core;
using NATS.Net;
using TwitchChat.Infrastructure.Messaging.Options;

namespace TwitchChat.Infrastructure.Messaging.Jetstreams;

public class NatsConnectionFactory(IOptions<NatsOptions> options): IConnectionFactory
{
    public INatsClient CreateClient()
    {
        return new NatsClient(new NatsOpts
        {
            Url = options.Value.ServerUrl ?? string.Empty,
            AuthOpts = new NatsAuthOpts()
            {
                Username = options.Value.Username,
                Password = options.Value.Password
            }
        });
    }
}