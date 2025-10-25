using TwitchChat.Domain.Events;
using TwitchChat.Shared.Messages;

namespace TwitchChat.Application;

public class ConsumeService(IMessageConsumer<ChatMessageEvent> messageConsumer, ILogger<ConsumeService> logger): BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            logger.LogInformation("Consume service starting...");
            await messageConsumer.StartConsumeAsync(stoppingToken);
        }
        catch (Exception e)
        {
            await messageConsumer.StopConsumeAsync(stoppingToken);
            logger.LogError(e, "Consume service failed");
            throw;
        }
        finally
        {
            logger.LogInformation("Consume service stopped");
        }
    }
}