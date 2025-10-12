using System.Xml.Schema;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;
using NATS.Client.JetStream;
using NATS.Client.Service;
using TwitchChat.Infrastructure.Messaging.Jetstreams;
using TwitchChat.Shared.Events;

namespace TwitchChat.Infrastructure.Messaging;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddJetstreamsPublisher(this IServiceCollection services, IConfiguration config)
  {
    services.AddSingleton<IConnection>(serviceProvider =>
    {
      var connectionFactory = new ConnectionFactory();
      var options = ConnectionFactory.GetDefaultOptions();
      options.Url = config["Nats:url"] ?? "nats://localhost:4222";
      return connectionFactory.CreateConnection(options);
    });


    services.AddSingleton<IJetStream>(serviceProvider =>
    {
      var connection = serviceProvider.GetRequiredService<IConnection>();
      return connection.CreateJetStreamContext();
    });

    services.AddSingleton<IJetStreamManagement>(serviceProvider =>
    {
      var connection = serviceProvider.GetRequiredService<IConnection>();
      return connection.CreateJetStreamManagementContext();
    });

    services.AddKeyedScoped<IEventPublisher, JetstreamEventPublisher>("JetStream");

    return services;
  }

  public static IServiceCollection AddJetstreamsListener(this IServiceCollection services, IConfiguration config)
  {
    return services;
  }
}
