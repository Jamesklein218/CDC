using NATS.Client.Core;

namespace TwitchChat.Infrastructure.Messaging.Jetstreams;

public interface IConnectionFactory
{
    INatsClient CreateClient();
}