---
name: searx
description: >
  Web search via SearXNG CLI. Search the internet, filter by category,
  language, time range, and more. Designed for AI agents with minimal,
  token-efficient output.
  TRIGGER: When the user asks to search the web, find information online,
  or lookup something on the internet.
allowed-tools: Bash(searx)
version: "0.1.2"
---

# SearXNG.Cli — Web Search

Lightweight CLI for searching via SearXNG instances. Output is plain text,
numbered list — minimal tokens for AI agents.

## Prerequisites

```bash
searx --version
```

If not installed:
```bash
dotnet tool install --global SearXNG.Cli
```

## Basic Search

```bash
searx "dotnet core"
```

## Filtering Results

**By category:**
```bash
searx "AI news" --category news
```

**By language:**
```bash
searx "python tutorial" --lang ru
```

**By time range:**
```bash
searx "openai gpt-5" --time week
```

**By safe search level:**
```bash
searx "query" --safe 2
```

**Limit result count:**
```bash
searx "query" --count 5
```

**Custom instance:**
```bash
searx "query" --instance https://search.example.com
```

## Configuration File

Set defaults in `~/.config/searx/config.json`:

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

Priority: CLI flags > config file > built-in defaults.

**Interactive setup:**
```bash
# Via Claude Code slash command
/searx-init
```
This asks a few questions and writes the config file for you.

## Output Format

```
1. https://example.com/page
   Page Title
   Brief description...

2. https://example.com/another
   Another Title
   Another description...
```

## Categories

| Category | Description |
|----------|-------------|
| `general` | General web search |
| `news` | News articles |
| `images` | Image search |
| `videos` | Video search |
| `it` | IT / tech |
| `science` | Scientific papers |
| `music` | Music |

## Time Ranges

| Value | Description |
|-------|-------------|
| `day` | Last 24 hours |
| `week` | Last 7 days |
| `month` | Last 30 days |
| `year` | Last 365 days |

## Error Handling

| Error | Fix |
|-------|-----|
| `403 Forbidden` | JSON format disabled on SearXNG instance. Enable it in `settings.yml` |
| `Connection refused` | Check instance URL and network connectivity |
| No results | Try a different query or remove filters |

## Best Practices

- **Use config file** for frequently used defaults (language, instance)
- **Keep `--count` low** for AI context efficiency (default 10 is usually enough)
- **Combine filters** for precise results: `--category news --time day --lang en`
- **Check instance health** if searches suddenly fail

## CLI Reference

See [CLI_REFERENCE.md](${CLAUDE_SKILL_DIR}/resources/CLI-REFERENCE.md) for complete documentation.
