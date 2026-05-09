# SearXNG.Cli — CLI Reference

## Installation

```bash
dotnet tool install --global SearXNG.Cli
```

## Commands

### `searx <query>`

Perform a web search.

**Arguments:**
- `query` (required) — Search query string

**Options:**
| Option | Short | Type | Default | Description |
|--------|-------|------|---------|-------------|
| `--category` | -c | string? | — | Filter by category |
| `--lang` | -l | string? | — | Language code |
| `--time` | -t | string? | — | Time range filter |
| `--safe` | -s | int? | — | Safe search level (0, 1, 2) |
| `--count` | -n | int | 10 | Max results to display |
| `--instance` | -i | string | https://searxng.local | SearXNG instance URL |

**Examples:**
```bash
searx "dotnet core"
searx "AI news" --category news --lang en --time week
searx "python" --lang ru --count 5
searx "query" --instance https://search.example.com
```

## Configuration File

**Path:** `~/.config/searx/config.json`

**Schema:**
```json
{
  "instance": "string",
  "category": "string?",
  "language": "string?",
  "timeRange": "string?",
  "safeSearch": "int?",
  "count": "int"
}
```

## Environment Variables

None currently supported. Use config file or CLI flags.

## Exit Codes

| Code | Meaning |
|------|---------|
| 0 | Success |
| 1 | Error (network, parsing, etc.) |
