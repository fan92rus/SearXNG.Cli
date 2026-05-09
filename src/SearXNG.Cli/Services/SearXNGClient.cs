using System.Net;
using System.Text.Json;
using SearXNG.Cli.Models;

namespace SearXNG.Cli.Services;

public class SearXNGClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public SearXNGClient(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
    }

    public SearXNGClient(string baseUrl)
        : this(new HttpClient(), baseUrl)
    {
    }

    public async Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        var queryParams = new List<string>
        {
            $"q={Uri.EscapeDataString(request.Query)}",
            "format=json"
        };

        if (!string.IsNullOrEmpty(request.Category))
            queryParams.Add($"categories={Uri.EscapeDataString(request.Category)}");

        if (!string.IsNullOrEmpty(request.Language))
            queryParams.Add($"language={Uri.EscapeDataString(request.Language)}");

        if (!string.IsNullOrEmpty(request.TimeRange))
            queryParams.Add($"time_range={Uri.EscapeDataString(request.TimeRange)}");

        if (request.SafeSearch.HasValue)
            queryParams.Add($"safesearch={request.SafeSearch.Value}");

        if (request.Page > 1)
            queryParams.Add($"pageno={request.Page}");

        var url = $"{_baseUrl.TrimEnd('/')}/search?{string.Join("&", queryParams)}";

        using var response = await _httpClient.GetAsync(url, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Forbidden)
            throw new InvalidOperationException("SearXNG instance returned 403 Forbidden. The JSON format may be disabled in the instance settings.");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var searchResponse = JsonSerializer.Deserialize<SearchResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return searchResponse ?? new SearchResponse();
    }
}
