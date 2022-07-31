using System.Xml.Schema;
using DefaultNamespace;
using Discord.WebSocket;
using SysBot.Constants;

namespace SysBot.Services.Handlers;

internal class CommandsHandlerService : ICommandsHandlerService
{
    private const int RandomLimiter = 10;
    private readonly IConfigInitializationService _configInitializationService;
    private readonly IRngService _rngService;

    public CommandsHandlerService(IConfigInitializationService configInitializationService, IRngService rngService)
    {
        _configInitializationService = configInitializationService;
        _rngService = rngService;
    }

    public Task CommandsHandler(SocketMessage message)
    {
        var prefix = _configInitializationService.GetCommandsPrefix() + ' ';

        if (!message.Author.IsBot && message.Content.StartsWith(prefix))
        {
            ImagesCommandsHandler(message, prefix);
        }
        return Task.CompletedTask;
    }

    private void ImagesCommandsHandler(SocketMessage message, string prefix)
    {
        if (message.Content == prefix + BotCommands.Dimasik)
        {
            SendImagesMessage(BotCommands.Dimasik, message);
        }

        if (message.Content == prefix + BotCommands.Grin)
        {
            SendImagesMessage(BotCommands.Grin, message);
        }

        if (message.Content == prefix + BotCommands.Hohma)
        {
            SendImagesMessage(BotCommands.Hohma, message);
        }

        if (message.Content == prefix + BotCommands.Korol)
        {
            SendImagesMessage(BotCommands.Korol, message);
        }
    }
    private void SendImagesMessage(string imageName, SocketMessage message)
    { 
        message.Channel.SendMessageAsync(
            ImagesConstants.ImagesBaseUri + 
            imageName + 
            _rngService.GetRandomNumber(RandomLimiter) + 
            ".jpg");
        Console.WriteLine($"Image for {BotCommands.Hohma} was sent successfully");
    }
}