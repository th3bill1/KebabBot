# T3MusicBot

T3MusicBot is a Discord slash-command bot written in C# with .NET 8. It provides music playback through Lavalink, lyrics lookup through Genius, weather lookup through OpenWeatherMap, and ChatGPT responses through OpenAI.

## Requirements

- Windows (the current implementation uses files under `C:\Program Files\T3MusicBot`)
- .NET 8 SDK
- A Discord bot application and token
- A running Lavalink v4 server
- API tokens for the optional Genius, OpenWeatherMap, and OpenAI integrations

## Configuration

Create the configuration directory before starting the bot:

```powershell
New-Item -ItemType Directory -Force 'C:\Program Files\T3MusicBot'
```

Create these files. Each token file should contain only its token; a trailing newline is fine.

| File | Contents |
| --- | --- |
| `discord_token.txt` | Discord bot token |
| `genius_token.txt` | Genius API token, required by `/tekst` |
| `openweather_token.txt` | OpenWeatherMap API key, required by `/pogoda` |
| `gpt_token.txt` | OpenAI API key, required by `/gpt` |

Create `lavalink.txt` with exactly two lines:

```text
127.0.0.1
2333
```

The first line is the Lavalink hostname and the second is its port. The bot currently uses Lavalink's default authorization value, `youshallnotpass`, so the Lavalink server must be configured with the same password.

Keep all token files out of source control. The bot must also be invited to the Discord server with the `bot` and `applications.commands` scopes and permissions to view, send messages, connect to voice, and speak. Enable the Message Content intent in the Discord Developer Portal.

## Build and run

From the repository root:

```powershell
dotnet restore .\T3MusicBot\T3MusicBot.csproj
dotnet run --project .\T3MusicBot\T3MusicBot.csproj
```

The process stays running until it is stopped. Slash commands are registered when the bot starts; Discord may take a short time to display newly registered commands.

## Commands

### Music

- `/play <search>` - join your voice channel and queue a track or playlist
- `/skip` - skip the current track
- `/pause` - pause playback
- `/resume` - resume playback
- `/leave` - leave the voice channel
- `/playlist` - show the current queue
- `/remove <position>` - remove a queue entry (positions start at 1)
- `/volume <value>` - change the volume
- `/current_volume` - show the current volume
- `/tekst [tytuł]` - fetch lyrics for a title or the currently playing track

### Utility

- `/ping` - show the Discord gateway latency
- `/echo <echo>` - repeat text
- `/pogoda <miasto>` - show the current temperature for a city
- `/gpt <text>` - ask ChatGPT a question
- `/czystka <amount>` - delete a number of recent messages after a delay

The bot also registers the `pin` message command for pinning a message and the `zwyzywaj` user command.

## Project layout

- `T3MusicBot/Program.cs` - application entry point
- `T3MusicBot/Services/DiscordService.cs` - Discord and Lavalink startup
- `T3MusicBot/Modules/AudioModule.cs` - music commands
- `T3MusicBot/Modules/TextModule.cs` - utility and text commands
- `T3MusicBot/Victoria/` - bundled Victoria Lavalink client library