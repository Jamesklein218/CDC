using System.Xml.Schema;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;
using NATS.Client.JetStream;
using TwitchChat.Infrastructure.Messaging.Jetstreams;
using TwitchChat.Shared.Events;
using TwitchChat.Shared.Messages;

namespace TwitchChat.Infrastructure.Messaging;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddJetstreamsPublisher(this IServiceCollection services, IConfiguration config)
  {
    services
      .AddKeyedScoped<IMessageProducer<IDomainEvent>, BaseJetstreamProducer<IDomainEvent>>("JetStream");

    return services;
  }

  public static IServiceCollection AddJetstreamsConsumers(this IServiceCollection services, IConfiguration config)
  {
    return services;
  }
}
