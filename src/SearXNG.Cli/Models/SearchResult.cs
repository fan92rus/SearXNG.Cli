namespace SearXNG.Cli.Models;

public class SearchResult
{
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Engine { get; set; }
    public double? Score { get; set; }
    public string? Category { get; set; }
}
