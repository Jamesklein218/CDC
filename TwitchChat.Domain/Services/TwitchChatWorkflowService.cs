namespace TwitchChat.Domain.Services;

using Interfaces;
using Values;
using TwitchChat.Domain.Entities;
using TwitchChat.Domain.Publishers;
using TwitchChat.Domain.Repositories;
using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Events;

public class TwitchChatWorkflowService(
  IUserRepository userRepository,
  ILeaderboardSessionRepository leaderboardSessionRepository,
  IWorkflowEventPublisher workflowEventPublisher
) : ITwitchChatWorkflowService
{
  /// <inheritdoc/>
  public async Task ProcessMessageAsync(ChatMessage message, CancellationToken token)
  {
    var events = new List<IEvent>();

    if (message.MessageType == ChatMessageType.Subscribe)
    {
      var currentUser = await userRepository.GetUserAsync(message.Username, token);

      var user = currentUser ?? await ChatUserRoot.CreateNewAsync(message.Username, token);

      user.HandleSubscription(events);

      await userRepository.SaveChangeAsync(token);
    }
    else
    {
      var session = await leaderboardSessionRepository.GetCurrentSessionAsync(
        message.TwitchLivestreamId,
        token
      );

      if (session != null && !session.IsFinished)
      {
        var spamEntry = new SpamEntry();
        await session.AddSpamEntryAsync(spamEntry, events, token);
      }

      await userRepository.SaveChangeAsync(token);
    }

    await workflowEventPublisher.PublishAsync(events, token);
  }

  /// <inheritdoc/>
  public async Task<LivestreamSession> CreateLivestreamSession(string livestreamId, CancellationToken token)
  {
    return new LivestreamSession();
  }

  /// <inheritdoc/>
  public async Task<LeaderboardSessionRoot> CreateLeaderboardSession(string liveStreamSessionId, CancellationToken token)
  {
    return new LeaderboardSessionRoot();
  }
}
