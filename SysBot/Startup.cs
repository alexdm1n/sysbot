using Discord;
using Discord.WebSocket;
using SysBot.Services;
using SysBot.Services.Handlers;

namespace SysBot
{
    class Startup
    {
        private DiscordSocketClient _client;
        private readonly IConfigInitializationService _configInitializationService;
        private readonly ILoggerService _loggerService;
        private readonly ICommandsHandlerService _commandsHandlerService;

        private Startup(
            IConfigInitializationService configInitializationService,
            ILoggerService loggerService,
            ICommandsHandlerService commandsHandlerService)
        {
            _configInitializationService = configInitializationService;
            _loggerService = loggerService;
            _commandsHandlerService = commandsHandlerService;
        }

        static void Main() => new Startup(
            configInitializationService: new ConfigInitializationService(),
            loggerService: new LoggerService(),
            commandsHandlerService: new CommandsHandlerService(new ConfigInitializationService(), new RngService())
            ).MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            var configuration = _configInitializationService.GetConfiguration();

            _client.Log += _loggerService.Log;
            _client.MessageReceived += _commandsHandlerService.CommandsHandler;

            await _client.LoginAsync(TokenType.Bot, configuration.BotToken);
            await _client.StartAsync();
            

            Console.ReadKey();
        }
    }
}
