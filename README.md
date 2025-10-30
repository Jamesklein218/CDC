The example service is a Twitch Chat Workflow Engine Service that takes data from a broker (e.g. `Jetstream`, etc.), process it by storing inside a KV store, and then publish domain events (via another broker, `Jetstream`, `RabbitMQ`, etc.). The KV Store will perform CDC that sink data to an SQL Store (e.g. `SQL Server`, etc.).

Business Logic includes:
- New subscriber -> store that new subscriber twitchUserId in KV Store and emit a `NewSubscriberEvent`
- Re-subscribe -> store that new subscriber twitchUserId in KV Store and emit a `ResubscribeEvent`
- Create a Leaderboard Session for n minutes (emit by using API) -> create a leaderboardSession in KV Store and emit a `NewLeaderboardEvent` inside a service.
- When a `SpamEvent` is detected, check if the leaderboard session is finished, if not, stored in the KV Store.

Add new migration script:

```
TwitchChat.Application$ dotnet ef migrations add <migration_name> --project TwitchChat.Migrations
```

Apply database update

```
TwitchChat.Application$ dotnet ef database update --project TwitchChat.Migrations
```

TODO:
- Implement Mock Ingestor to mock the Chat Messages
- Enable Change Data Capture to SQL Server and implement the
domain event publisher to ensure atomicity
- ...