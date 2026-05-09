# SearXNG.Cli

[![Release](https://github.com/fan92rus/SearXNG.Cli/actions/workflows/release.yml/badge.svg)](https://github.com/fan92rus/SearXNG.Cli/actions/workflows/release.yml)
[![NuGet](https://img.shields.io/nuget/v/SearXNG.Cli)](https://www.nuget.org/packages/SearXNG.Cli)

A lightweight cross-platform CLI tool for searching the web via [SearXNG](https://github.com/searxng/searxng) instances.

Designed with AI agents in mind: output is minimal, plain text, and token-efficient.

## Features

- **Plain text output** — numbered list with URL, title, and snippet. No tables, no ANSI colors, no bloat.
- **Configurable defaults** — set your preferred instance, language, category, and more in a config file.
- **Multiple install methods** — NuGet, GitHub Releases, CI artifacts, or build from source.
- **Cross-platform** — runs on Windows, macOS, and Linux.

## Requirements

- [.NET 8.0 SDK or Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)

## Installation

### From NuGet (recommended)

```bash
dotnet tool install --global SearXNG.Cli
```

Update to the latest version:
```bash
dotnet tool update --global SearXNG.Cli
```

### From GitHub Releases

1. Download the latest `.nupkg` from [Releases](https://github.com/fan92rus/SearXNG.Cli/releases)
2. Install:

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

## Uninstall

```bash
dotnet tool uninstall --global SearXNG.Cli
```

## Usage

### Basic search

```bash
searx "dotnet core"
```

### Filter by category

```bash
searx "AI news" --category news
```

### Filter by language and time

```bash
searx "python tutorial" --lang ru --time week
```

### Use a custom SearXNG instance

```bash
searx "query" --instance https://search.example.com
```

### Show more results

```bash
searx "open source" --count 20
```

## Options

| Option | Default | Description |
|--------|---------|-------------|
| `--category` | `general` | Category: `general`, `news`, `images`, `videos`, etc. |
| `--lang` | — | Language code, e.g. `en`, `ru`, `de` |
| `--time` | — | Time range: `day`, `week`, `month`, `year` |
| `--safe` | — | Safe search: `0` (off), `1` (moderate), `2` (strict) |
| `--count` | `10` | Maximum results to display |
| `--instance` | `https://searxng.local` | SearXNG instance URL |

## Configuration File

Instead of passing flags every time, set defaults in a config file.

**Location** (cross-platform):
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

Results are printed as a minimal plain-text list to keep token usage low for AI agents:

```
1. https://dotnet.microsoft.com/en-us/download
   Download .NET (Linux, macOS, and Windows) - Microsoft .NET
   NET Framework downloads for Windows? Download .NET Framework...

2. https://github.com/dotnet/core
   GitHub - dotnet/core: .NET news, announcements, release notes...
   Follow GitHub Discussions, where you will find the latest news...
```

## Building from Source

```bash
dotnet build
dotnet test
dotnet pack --configuration Release --output ./nupkg
```

## License

MIT
