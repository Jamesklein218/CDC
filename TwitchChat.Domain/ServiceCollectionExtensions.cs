using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitchChat.Domain.Services;
using TwitchChat.Domain.Services.Interfaces;

namespace CDC.Infrastructure;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddTwitchChatConfig(this IServiceCollection services, IConfiguration config)
  {
    return services;
  }

  public static IServiceCollection AddTwitchChatServices(this IServiceCollection services)
  {
    services.AddScoped<ITwitchChatWorkflowService, TwitchChatWorkflowService>();
    return services;
  }
}
