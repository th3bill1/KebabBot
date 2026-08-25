using T3MusicBot.Services;

namespace T3MusicBot
{
    public class T3MusicBotProgram
    {
        class Program
        {
            public static Task Main()
                => new DiscordService().InitializeAsync();
        }
    }
}