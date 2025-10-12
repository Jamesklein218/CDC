using Microsoft.Extensions.DependencyInjection;

namespace TwitchChat.Infrastructures;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddTwitchChatInfrastructure(this IServiceCollection services)
  {
    return services;
  }
}
