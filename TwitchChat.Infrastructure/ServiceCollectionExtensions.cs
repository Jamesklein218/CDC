using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TwitchChat.Infrastructure;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddTwitchChatConfig(this IServiceCollection services, IConfiguration config)
  {
    return services;
  }

  public static IServiceCollection AddTwitchChatInfrastructures(this IServiceCollection services)
  {
    return services;
  }
}
