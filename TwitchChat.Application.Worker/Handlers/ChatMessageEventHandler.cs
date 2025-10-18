using TwitchChat.Domain.Events;
using TwitchChat.Shared.Events;
using TwitchChat.Shared.Messages;

namespace TwitchChat.Application.Worker.Handlers;

public class ChatMessageEventHandler(
  IMessageProducer<ChatMessageEvent> chatMessageProducer
) : IDomainEventHandler<ChatMessageEvent>
{
  public async Task HandleAsync(ChatMessageEvent eventObj, CancellationToken token)
  {
    await chatMessageProducer.ProduceMessageAsync([eventObj], token);
  }
  public async Task BulkHandleAsync(IEnumerable<ChatMessageEvent> events, CancellationToken token)
  {
    await chatMessageProducer.ProduceMessageAsync(events, token);
  }
}
