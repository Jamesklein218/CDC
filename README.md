### Change Data Capture

This repository contains C# OVERENGINEER implementation of a Workflow Enginer Service that applies Change Data Capture (CDC). Everything in this repository is solely cooked up, highly opinionate and applies (barely) Domain-Driven Design architecture. This repository is only for education purposes and shouldn't be seen as a reference source whatsoever.

### Example Service: Twitch Chat

The example service is a Workflow Service that takes data from a broker (e.g. `Jetstream`, etc.), process it by storing inside a KV store, and then publish domain events. The KV Store will perform CDC that sink data to an SQL Store (e.g. `SQL Server`, etc.).

Business Logic includes:
- New subscriber -> store that new subscriber twitchUserId in KV Store and emit a `NewSubscriberEvent`
- Re-subscribe -> store that new subscriber twitchUserId in KV Store and emit a `ResubscribeEvent`
- Create a Leaderboard Session for n minutes (emit by using API) -> create a leaderboardSession in KV Store and emit a `NewLeaderboardEvent` inside a service, event message that is not a subscribe message now will treat as `SpamEvent`.
- When a `SpamEvent` is detected, check if the leaderboard session is finished, if not, stored in the KV Store.
