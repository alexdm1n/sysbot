using Discord;

namespace SysBot.Services;

internal class LoggerService : ILoggerService
{
    public Task Log(LogMessage message)
    {
        Console.WriteLine(message.ToString());
        return Task.CompletedTask;
    }
}