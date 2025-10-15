using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Events;
using TwitchChat.Shared.Events;

namespace TwitchChat.Application.Worker.Handlers;

public class ChatMessageEventHandler: IDomainEventHandler<ChatMessageEvent>
{
  public async Task HandleAsync(ChatMessageEvent eventObj, CancellationToken token)
  {
    throw new NotImplementedException();
  }
  public async Task BulkHandleAsync(IEnumerable<ChatMessageEvent> events, CancellationToken token)
  {
    throw new NotImplementedException();
  }
}
