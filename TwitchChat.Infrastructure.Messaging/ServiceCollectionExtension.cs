using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitchChat.Domain.Events;
using TwitchChat.Infrastructure.Messaging.Jetstreams;
using TwitchChat.Shared.Events;
using TwitchChat.Shared.Messages;

namespace TwitchChat.Infrastructure.Messaging;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddJetstreamsPublisher(this IServiceCollection services)
  {
    services
      .AddSingleton<IConnectionFactory, NatsConnectionFactory>()
      .AddKeyedSingleton<IMessageProducer<IDomainEvent>, BaseJetstreamProducer<IDomainEvent>>("JetStream")
      .AddKeyedSingleton<IMessageConsumer<ChatMessageEvent>, ChatMessageConsumer>("JetStream");

    return services;
  }

  public static void StartConsuming(this IServiceCollection services, IConfiguration config)
  {
    var consumer = services.BuildServiceProvider().GetRequiredService<IMessageConsumer<ChatMessageEvent>>();
    consumer.StartConsumeAsync();
  }
  
  public static void StopConsuming(this IServiceCollection services, IConfiguration config)
  {
  }
}
