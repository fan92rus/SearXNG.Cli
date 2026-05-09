---
description: Configure SearXNG.Cli defaults and create ~/.config/searx/config.json
---

Interactive setup for SearXNG.Cli. Creates or updates the config file with your preferred defaults.

**Step 1: Verify searx is installed**
```bash
searx --version
```
If not found, install it:
```bash
dotnet tool install --global SearXNG.Cli
```

**Step 2: Create config directory**
```bash
mkdir -p ~/.config/searx
```
(On Windows: the directory is `%USERPROFILE%\.config\searx`)

**Step 3: Ask the user for preferences**

Ask each question one at a time. If the user presses Enter without typing anything, use the default value.

| Setting | Question | Default |
|---------|----------|---------|
| `instance` | SearXNG instance URL (e.g. https://searxng.local) | `https://searxng.local` |
| `language` | Default language code (e.g. en, ru, de) | (none) |
| `category` | Default category (e.g. general, news, images) | (none) |
| `timeRange` | Default time range (day, week, month, year) | (none) |
| `safeSearch` | Default safe search level (0=off, 1=moderate, 2=strict) | (none) |
| `count` | Default number of results (1-50) | `10` |

**Step 4: Write config file**

Write the collected values to `~/.config/searx/config.json` (or `%USERPROFILE%\.config\searx\config.json` on Windows).

Only include fields that the user explicitly set or that have non-null defaults. Omit empty / null values.

Example output:
```json
{
  "instance": "https://searxng.local",
  "language": "ru",
  "category": "general",
  "count": 10
}
```

**Step 5: Confirm**

Show the user the final path and file contents, and confirm it was written successfully.

```bash
cat ~/.config/searx/config.json
```
