using SearXNG.Cli.Models;

namespace SearXNG.Cli.Formatters;

public static class PlainTextFormatter
{
    public static string Format(SearchResponse response, int maxResults = 10)
    {
        if (response.Results.Count == 0)
            return "No results found.";

        var lines = new List<string>();
        var results = response.Results.Take(maxResults).ToList();

        for (int i = 0; i < results.Count; i++)
        {
            var r = results[i];
            lines.Add($"{i + 1}. {r.Url}");
            lines.Add($"   {r.Title}");
            if (!string.IsNullOrWhiteSpace(r.Content))
            {
                lines.Add($"   {r.Content}");
            }
            lines.Add(string.Empty);
        }

        return string.Join(Environment.NewLine, lines);
    }
}
