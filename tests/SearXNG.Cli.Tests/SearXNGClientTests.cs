using System.Net;
using System.Text.Json;
using SearXNG.Cli.Models;
using SearXNG.Cli.Services;

namespace SearXNG.Cli.Tests;

public class SearXNGClientTests
{
    private static HttpClient CreateMockClient(HttpStatusCode statusCode, string content)
    {
        var handler = new TestHandler(statusCode, content);
        return new HttpClient(handler);
    }

    [Fact]
    public async Task SearchAsync_ReturnsParsedResults()
    {
        var response = new SearchResponse
        {
            Query = "dotnet",
            NumberOfResults = 2,
            Results =
            [
                new SearchResult { Title = "Result 1", Url = "https://example.com/1", Content = "Content 1", Engine = "google" },
                new SearchResult { Title = "Result 2", Url = "https://example.com/2", Content = "Content 2", Engine = "bing" }
            ]
        };

        var json = JsonSerializer.Serialize(response);
        var client = new SearXNGClient(CreateMockClient(HttpStatusCode.OK, json), "https://searxng.local");

        var result = await client.SearchAsync(new SearchRequest { Query = "dotnet" });

        Assert.Equal("dotnet", result.Query);
        Assert.Equal(2, result.Results.Count);
        Assert.Equal("Result 1", result.Results[0].Title);
        Assert.Equal("https://example.com/1", result.Results[0].Url);
    }

    [Fact]
    public async Task SearchAsync_IncludesQueryParameters()
    {
        var handler = new TestHandler(HttpStatusCode.OK, "{\"query\":\"test\",\"results\":[]}");
        var httpClient = new HttpClient(handler);
        var client = new SearXNGClient(httpClient, "https://searxng.local");

        await client.SearchAsync(new SearchRequest
        {
            Query = "test query",
            Category = "news",
            Language = "ru",
            TimeRange = "week",
            SafeSearch = 2,
            Page = 2
        });

        var requestUri = handler.LastRequest?.RequestUri?.OriginalString ?? "";
        Assert.Contains("q=test%20query", requestUri);
        Assert.Contains("format=json", requestUri);
        Assert.Contains("categories=news", requestUri);
        Assert.Contains("language=ru", requestUri);
        Assert.Contains("time_range=week", requestUri);
        Assert.Contains("safesearch=2", requestUri);
        Assert.Contains("pageno=2", requestUri);
    }

    [Fact]
    public async Task SearchAsync_ThrowsOnForbidden()
    {
        var client = new SearXNGClient(CreateMockClient(HttpStatusCode.Forbidden, ""), "https://searxng.local");

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(
            () => client.SearchAsync(new SearchRequest { Query = "test" }));

        Assert.Contains("403 Forbidden", ex.Message);
    }

    private class TestHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _content;

        public HttpRequestMessage? LastRequest { get; private set; }

        public TestHandler(HttpStatusCode statusCode, string content)
        {
            _statusCode = statusCode;
            _content = content;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequest = request;
            var response = new HttpResponseMessage(_statusCode)
            {
                Content = new StringContent(_content)
            };
            return Task.FromResult(response);
        }
    }
}
