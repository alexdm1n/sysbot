using Discord.WebSocket;

namespace SysBot.Services.Handlers;

internal interface ICommandsHandlerService
{
    Task CommandsHandler(SocketMessage message);
}