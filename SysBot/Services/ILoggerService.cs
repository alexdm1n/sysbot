using Discord;

namespace SysBot.Services;

internal interface ILoggerService
{
    Task Log(LogMessage message);
}