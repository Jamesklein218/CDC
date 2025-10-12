using System;
using TwitchChat.Domain.Aggregates;
using TwitchChat.Domain.Entities;

namespace TwitchChat.Domain.Services.Interfaces;

public interface ITwitchChatWorkflowService
{
  /// <summary>
  /// Central business logic to process a new chat bot
  /// </summary>
  Task ProcessMessageAsync(ChatMessage message, CancellationToken token);

  /// <summary>
  /// Create a new live stream session business logic
  /// </summary>
  Task<LiveStreamSession> CreateLivestreamSession(string livestreamId, CancellationToken token);

  /// <summary>
  /// Create new Leaderboard session from a livestream session
  /// </summary>
  Task<LeaderboardSession> CreateLeaderboardSession(string liveStreamSessionId, CancellationToken token);
}
