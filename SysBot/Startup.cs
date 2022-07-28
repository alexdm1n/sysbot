using Discord.WebSocket;

namespace SysBot
{
    class Startup
    {
        private static DiscordSocketClient _client;

        static void Main() => new Startup().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            _client = new DiscordSocketClient();
        }
    }
}
