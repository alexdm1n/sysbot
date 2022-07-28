using System.Text.Json;
using SysBot.Constants;
using SysBot.Exceptions;
using SysBot.Models;

namespace SysBot.Services;

internal class ConfigInitializationService : IConfigInitializationService
{
    public AppConfiguration GetConfiguration()
    {
        var deserializedConfiguration = File.ReadAllText(ConfigurationConstants.ConfigurationFileName);
        var configuration = JsonSerializer.Deserialize<AppConfiguration>(deserializedConfiguration);
        if (configuration != null)
        {
            return configuration;
        }

        throw new EmptyConfigurationException(
            $"Please provide your bot details in the file {ConfigurationConstants.ConfigurationFileName}");
    }
}