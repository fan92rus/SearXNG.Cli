---
description: Search the web via SearXNG CLI
---

Search the web using the SearXNG CLI tool.

**Step 1: Run search**
```bash
searx "<query>" [--category <cat>] [--lang <lang>] [--time <range>] [--count <n>]
```

**Step 2: Analyze results**
- Summarize the top results with URLs, titles, and snippets
- If no results: report "No results found"

**Step 3: Suggest next actions**
- If results are insufficient: suggest a refined query
- If a specific page looks relevant: offer to visit it

**Examples:**
```bash
searx "dotnet core latest features" --count 5
searx "AI news" --category news --lang en --time week
searx "python tutorial" --lang ru
```
