using SearXNG.Cli.Models;
using SearXNG.Cli.Services;

namespace SearXNG.Cli.Tests;

public class ConfigLoaderTests : IDisposable
{
    private readonly string _tempDir;

    public ConfigLoaderTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    [Fact]
    public void Load_MissingFile_ReturnsDefaults()
    {
        var path = Path.Combine(_tempDir, "nonexistent.json");
        var config = ConfigLoader.Load(path);

        Assert.Equal("https://searxng.local", config.Instance);
        Assert.Equal(10, config.Count);
        Assert.Null(config.Language);
    }

    [Fact]
    public void Load_ValidFile_ReturnsParsedConfig()
    {
        var path = Path.Combine(_tempDir, "config.json");
        File.WriteAllText(path, """
            {
                "instance": "https://custom.example.com",
                "language": "ru",
                "category": "news",
                "count": 5
            }
            """);

        var config = ConfigLoader.Load(path);

        Assert.Equal("https://custom.example.com", config.Instance);
        Assert.Equal("ru", config.Language);
        Assert.Equal("news", config.Category);
        Assert.Equal(5, config.Count);
    }

    [Fact]
    public void Load_InvalidJson_ReturnsDefaults()
    {
        var path = Path.Combine(_tempDir, "config.json");
        File.WriteAllText(path, "not json");

        var config = ConfigLoader.Load(path);

        Assert.Equal("https://searxng.local", config.Instance);
        Assert.Equal(10, config.Count);
    }
}
