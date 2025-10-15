namespace TwitchChat.Infrastructure.Messaging.Options;

public class NatsOptions
{
  public string Url { get; set; } = "nats://127.0.0.1";
  public string Port { get; set; } = "4222";
}
