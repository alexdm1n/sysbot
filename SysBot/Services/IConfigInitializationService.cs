using SysBot.Models;

namespace SysBot.Services;

internal interface IConfigInitializationService
{
    AppConfiguration GetConfiguration();
}