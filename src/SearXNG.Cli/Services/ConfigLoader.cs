using System.Text.Json;
using SearXNG.Cli.Models;

namespace SearXNG.Cli.Services;

public static class ConfigLoader
{
    public static string GetConfigPath()
    {
        var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return Path.Combine(home, ".config", "searx", "config.json");
    }

    public static Config Load(string? path = null)
    {
        var configPath = path ?? GetConfigPath();

        if (!File.Exists(configPath))
            return new Config();

        try
        {
            var json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<Config>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return config ?? new Config();
        }
        catch (JsonException)
        {
            return new Config();
        }
    }
}
