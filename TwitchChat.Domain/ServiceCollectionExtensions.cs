using Microsoft.Extensions.DependencyInjection;
using TwitchChat.Domain.Services;
using TwitchChat.Domain.Services.Interfaces;

namespace CDC.Domain;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddTwitchChatServices(this IServiceCollection services)
  {
    services.AddScoped<ITwitchChatWorkflowService, TwitchChatWorkflowService>();
    return services;
  }
}
