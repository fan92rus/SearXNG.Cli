# SearXNG.Cli

A lightweight cross-platform CLI tool for searching the web via [SearXNG](https://github.com/searxng/searxng) instances.

## Installation

### From NuGet (recommended)

Package: [SearXNG.Cli on NuGet](https://www.nuget.org/packages/SearXNG.Cli)

```bash
dotnet tool install --global SearXNG.Cli
```

To update:
```bash
dotnet tool update --global SearXNG.Cli
```

### From GitHub Releases

1. Download the latest `.nupkg` from [Releases](https://github.com/fan92rus/SearXNG.Cli/releases)
2. Install from the local file:

```bash
dotnet tool install --global SearXNG.Cli --add-source ./path-to-downloaded-nupkg
```

### From CI Artifacts

1. Go to [Actions](https://github.com/fan92rus/SearXNG.Cli/actions) and open the latest successful run
2. Download the `nupkg` artifact and extract it
3. Install:

```bash
dotnet tool install --global SearXNG.Cli --add-source ./extracted-folder
```

### From Source

```bash
git clone https://github.com/fan92rus/SearXNG.Cli.git
cd SearXNG.Cli
dotnet pack --configuration Release --output ./nupkg
dotnet tool install --global --add-source ./nupkg SearXNG.Cli
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

## Configuration File

Instead of passing flags every time, you can set defaults in a config file.

**Config location** (cross-platform):
- Windows: `%USERPROFILE%\.config\searx\config.json`
- Linux / macOS: `~/.config/searx/config.json`

**Example `config.json`**:

```json
{
  "instance": "https://searxng.local",
  "category": "general",
  "language": "ru",
  "timeRange": "week",
  "safeSearch": 1,
  "count": 10
}
```

**Priority**: CLI flags > config file > built-in defaults.

If the config file is missing or contains invalid JSON, built-in defaults are used automatically.

## Output Format

Results are printed as a plain text list to keep token usage minimal for AI agents:

```
1. https://example.com/page
   Page Title
   Brief description of the result...

2. https://example.com/another
   Another Title
   Another description...
```

## Building from Source

```bash
dotnet build
dotnet test
dotnet pack --configuration Release --output ./nupkg
```

## License

MIT
