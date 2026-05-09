namespace SearXNG.Cli.Models;

public class SearchRequest
{
    public string Query { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string? Language { get; set; }
    public string? TimeRange { get; set; }
    public int? SafeSearch { get; set; }
    public int Page { get; set; } = 1;
}
