using System.CommandLine;
using SearXNG.Cli.Formatters;
using SearXNG.Cli.Models;
using SearXNG.Cli.Services;

namespace SearXNG.Cli.Commands;

public static class SearchCommand
{
    public static Command Create()
    {
        var queryArg = new Argument<string>("query", "Search query string");

        var categoryOption = new Option<string?>("--category", "Filter by category (e.g., general, news, images, videos)");
        var languageOption = new Option<string?>("--lang", "Language code (e.g., en, ru, de)");
        var timeOption = new Option<string?>("--time", "Time range filter: day, week, month, year");
        var safeOption = new Option<int?>("--safe", "Safe search level: 0 (off), 1 (moderate), 2 (strict)");
        var countOption = new Option<int>("--count", () => 10, "Maximum number of results to display");
        var instanceOption = new Option<string>("--instance", () => "https://searxng.local", "SearXNG instance URL");

        var command = new Command("searx", "Search the web via SearXNG")
        {
            queryArg,
            categoryOption,
            languageOption,
            timeOption,
            safeOption,
            countOption,
            instanceOption
        };

        command.SetHandler(async (string query, string? category, string? lang, string? time, int? safe, int count, string instance) =>
        {
            var request = new SearchRequest
            {
                Query = query,
                Category = category,
                Language = lang,
                TimeRange = time,
                SafeSearch = safe
            };

            var client = new SearXNGClient(instance);
            var response = await client.SearchAsync(request);
            var output = PlainTextFormatter.Format(response, count);
            Console.WriteLine(output);
        }, queryArg, categoryOption, languageOption, timeOption, safeOption, countOption, instanceOption);

        return command;
    }
}
