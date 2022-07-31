using Discord.WebSocket;

namespace SysBot.Services.Handlers;

internal class CommandsHandlerService : ICommandsHandlerService
{
    private readonly IConfigInitializationService _configInitializationService;

    public CommandsHandlerService(IConfigInitializationService configInitializationService)
    {
        _configInitializationService = configInitializationService;
    }

    public Task CommandsHandler(SocketMessage message)
    {
        var prefix = _configInitializationService.GetCommandsPrefix();

        if (!message.Author.IsBot && message.Content.StartsWith(prefix))
        {
        }
        return Task.CompletedTask;
    }
}