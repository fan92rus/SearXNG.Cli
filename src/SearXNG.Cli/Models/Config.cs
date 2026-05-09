namespace SearXNG.Cli.Models;

public class Config
{
    public string Instance { get; set; } = "https://searxng.local";
    public string? Category { get; set; }
    public string? Language { get; set; }
    public string? TimeRange { get; set; }
    public int? SafeSearch { get; set; }
    public int Count { get; set; } = 10;
}
