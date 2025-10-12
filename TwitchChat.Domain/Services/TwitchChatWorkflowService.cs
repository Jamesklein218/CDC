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
  ILivestreamSessionRepository livestreamSessionRepository,
  IWorkflowEventPublisher workflowEventPublisher
) : ITwitchChatWorkflowService
{
  /// <inheritdoc/>
  public async Task ProcessMessageAsync(ChatMessage message, CancellationToken token)
  {
    var events = new List<IEvent>();

    if (message.MessageType == ChatMessageType.Subscribe)
    {
      var user = await userRepository.GetOrCreateNewAsync(message.TwitchUserId, token);

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
  public async Task<LiveStreamSession> CreateLivestreamSession(
    string twitchLiveStreamid,
    CancellationToken token
  )
  {
    // Note: In the real implementation, this should be a separate service, because we need to keep track if the twitch Livestream is valid or not.
    return await livestreamSessionRepository.CreateNewAsync(twitchLiveStreamid, token);
  }

  /// <inheritdoc/>
  public async Task<LeaderboardSession> CreateLeaderboardSession(string liveStreamSessionId, CancellationToken token)
  {
    return await leaderboardSessionRepository.CreateNewAsync(liveStreamSessionId, token);
  }
}
