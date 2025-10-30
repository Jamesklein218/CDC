namespace TwitchChat.Domain.Services;

using Interfaces;
using Model;
using Entities;
using Repositories;
using Events;
using TwitchChat.Shared.Events;

public class TwitchChatWorkflowService(
  IUserRepository userRepository,
  ILeaderboardSessionRepository leaderboardSessionRepository,
  ILivestreamSessionRepository livestreamSessionRepository,
  IDomainEventPublisher eventPublisher
) : ITwitchChatWorkflowService
{
  /// <inheritdoc/>
  public async Task ProcessMessageAsync(ChatMessage message, CancellationToken token)
  {
    var events = new List<IDomainEvent>();

    try
    {
      if (message.MessageType == ChatMessageType.Subscribe)
      {
        var user = await userRepository.GetOrCreateNewAsync(message.TwitchUserId, token);

        user.HandleSubscription(message.TwitchLivestreamId);

        events.AddRange(user.DomainEvents);

        await userRepository.SaveChangeAsync(token);
      }
      else
      {
        var session = await leaderboardSessionRepository.GetChatUserLeaderboardSessionAsync(
          message.TwitchLivestreamId,
          token
        );

        if (session != null && !session.IsSessionFinished)
        {
          var spamEntry = new SpamEntry();

          session.AddSpamEntry(spamEntry);

          events.AddRange(session.DomainEvents);
        }

        await userRepository.SaveChangeAsync(token);
      }
    }
    catch (ArgumentException e)
    {
      // Invalid data, should be captured and put in an event for tracking
      Console.WriteLine(e);
      return;
    }

    await eventPublisher.PublishAsync(events, token);
  }

  /// <inheritdoc/>
  public async Task<LiveStreamSession> CreateLivestreamSession(
    string twitchLiveStreamid,
    CancellationToken token
  )
  {
    // Note: In the real implementation, this should be a separate service, because we need to keep track if the twitch Livestream is valid or not.
    var newLiveStreamSession
      = await livestreamSessionRepository.CreateNewAsync(twitchLiveStreamid, token);
    await livestreamSessionRepository.SaveChangeAsync(token);
    return newLiveStreamSession;
  }

  /// <inheritdoc/>
  public async Task<LeaderboardSession> CreateLeaderboardSession(string liveStreamSessionId, CancellationToken token)
  {
    var newLeaderboardSession = await leaderboardSessionRepository.CreateNewAsync(liveStreamSessionId, token);

    await leaderboardSessionRepository.SaveChangeAsync(token);

    // TODO: Make this atomic with SaveChangeAsync by applying base class
    await eventPublisher.PublishAsync([
      new NewLeaderboardEvent()
    ], token);

    return newLeaderboardSession;
  }
}
