using TwitchChat.Domain.Events;
using TwitchChat.Domain.Services.Interfaces;
using TwitchChat.Shared.Events;

namespace TwitchChat.Application.Events.Handlers;

public class ChatMessageEventHandler(ITwitchChatWorkflowService service): IDomainEventHandler<ChatMessageEvent>
{
    public async Task HandleAsync(ChatMessageEvent eventObj, CancellationToken token)
    {
        await service.ProcessMessageAsync(eventObj.ChatMessage, token);
    }

    public Task BulkHandleAsync(IEnumerable<ChatMessageEvent> events, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}