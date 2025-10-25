using System;

namespace TwitchChat.Infrastructure.Messaging.Options;

public class NatsOptions
{
    public string? ServerUrl { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool EnableTls { get; set; }
}
