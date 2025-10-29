using TwitchChat.Application;
using TwitchChat.Domain;
using TwitchChat.Infrastructure.Messaging;
using TwitchChat.Infrastructure.Messaging.Options;
using TwitchChat.Infrastructure.Persistence;

var builder = Host.CreateApplicationBuilder(args);

var configuration = builder.Configuration;

builder.Services
    // Domain
    .AddTwitchChatServices()
    // Application
    .AddAppServices()
    // Infrastructures
    .Configure<NatsOptions>(builder.Configuration.GetSection("Nats"))
    .AddJetstreamMessaging()
    .AddSqlServerRepositories(configuration)
    .AddHostedService<ConsumeService>();

var host = builder.Build();

host.Run();
