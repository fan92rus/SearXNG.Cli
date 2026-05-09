using SearXNG.Cli.Formatters;
using SearXNG.Cli.Models;

namespace SearXNG.Cli.Tests;

public class PlainTextFormatterTests
{
    [Fact]
    public void Format_EmptyResults_ReturnsNoResults()
    {
        var response = new SearchResponse();
        var result = PlainTextFormatter.Format(response);
        Assert.Equal("No results found.", result);
    }

    [Fact]
    public void Format_SingleResult_FormatsCorrectly()
    {
        var response = new SearchResponse
        {
            Results =
            [
                new SearchResult
                {
                    Title = "Title",
                    Url = "https://example.com",
                    Content = "Description"
                }
            ]
        };

        var result = PlainTextFormatter.Format(response);

        Assert.Contains("1. https://example.com", result);
        Assert.Contains("   Title", result);
        Assert.Contains("   Description", result);
    }

    [Fact]
    public void Format_RespectsMaxResults()
    {
        var response = new SearchResponse
        {
            Results = Enumerable.Range(1, 20)
                .Select(i => new SearchResult { Title = $"Result {i}", Url = $"https://example.com/{i}", Content = "" })
                .ToList()
        };

        var result = PlainTextFormatter.Format(response, 5);
        var lines = result.Split(Environment.NewLine);

        Assert.DoesNotContain("6. https://example.com/6", result);
    }
}
