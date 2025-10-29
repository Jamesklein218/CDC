using TwitchChat.Application.Events.Handlers;
using TwitchChat.Application.Events.Publishers;
using TwitchChat.Domain.Events;
using TwitchChat.Shared.Events;

namespace TwitchChat.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IDomainEventHandler<ChatMessageEvent>, ChatMessageEventHandler>()
            .AddSingleton<IDomainEventPublisher, DomainEventPublisher>();
    }
}