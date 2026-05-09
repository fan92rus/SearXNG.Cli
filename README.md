# SearXNG.Cli

A lightweight cross-platform CLI tool for searching the web via [SearXNG](https://github.com/searxng/searxng) instances.

## Installation

```bash
dotnet tool install --global SearXNG.Cli
```

## Usage

```bash
# Basic search
searx "dotnet core"

# Filter by category
searx "AI news" --category news

# Filter by language and time
searx "python tutorial" --lang ru --time week

# Use custom instance
searx "query" --instance https://search.example.com
```

## Options

| Option | Description |
|--------|-------------|
| `--category` | Filter by category: `general`, `news`, `images`, `videos`, etc. |
| `--lang` | Language code, e.g. `en`, `ru`, `de` |
| `--time` | Time range: `day`, `week`, `month`, `year` |
| `--safe` | Safe search level: `0`, `1`, `2` |
| `--count` | Maximum results to display (default: 10) |
| `--instance` | SearXNG instance URL (default: `https://searxng.local`) |

## Output format

Results are printed as a plain text list to keep token usage minimal for AI agents:

```
1. https://example.com/page
   Page Title
   Brief description of the result...

2. https://example.com/another
   Another Title
   Another description...
```

## Building from source

```bash
dotnet build
dotnet test
dotnet pack --output ./nupkg
dotnet tool install --global --add-source ./nupkg SearXNG.Cli
```

## License

MIT
