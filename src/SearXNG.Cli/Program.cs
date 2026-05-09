using System.CommandLine;
using SearXNG.Cli.Commands;

var rootCommand = SearchCommand.Create();
return await rootCommand.InvokeAsync(args);
