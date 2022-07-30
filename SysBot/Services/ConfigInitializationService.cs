using System.Text.Json;
using SysBot.Constants;
using SysBot.Exceptions;
using SysBot.Models;

namespace SysBot.Services;

internal class ConfigInitializationService : IConfigInitializationService
{
    public AppConfiguration GetConfiguration()
    {
        var deserializedConfiguration = File
            .ReadAllText(Path.GetFullPath(@"..\..\..\") + ConfigurationConstants.ConfigurationFileName);
        var configuration = JsonSerializer.Deserialize<AppConfiguration>(deserializedConfiguration);
        if (!string.IsNullOrEmpty(configuration.BotToken))
        {
            Console.WriteLine(
                $"Successfully received your app configuration: \nToken: {configuration.BotToken}\nPrefix: {configuration.CommandPrefix}");
            return configuration;
        }

        throw new EmptyConfigurationException(
            $"Please provide your bot configuration in the file {ConfigurationConstants.ConfigurationFileName}");
    }
}