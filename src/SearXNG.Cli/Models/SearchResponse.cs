namespace SearXNG.Cli.Models;

public class SearchResponse
{
    public string Query { get; set; } = string.Empty;
    public int NumberOfResults { get; set; }
    public List<SearchResult> Results { get; set; } = new();
    public List<string> Suggestions { get; set; } = new();
    public List<string> Corrections { get; set; } = new();
    public List<string> Answers { get; set; } = new();
    public List<string> UnresponsiveEngines { get; set; } = new();
}
