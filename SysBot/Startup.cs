using Discord.WebSocket;
using SysBot.Services;

namespace SysBot
{
    class Startup
    {
        private static DiscordSocketClient _client;
        private readonly IConfigInitializationService _configInitializationService;

        public Startup(IConfigInitializationService configInitializationService)
        {
            _configInitializationService = configInitializationService;
        }

        static void Main() => new Startup(configInitializationService: new ConfigInitializationService()).MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            var configuration = _configInitializationService.GetConfiguration();
            Console.WriteLine(configuration);
            Console.ReadKey();
        }
    }
}
