# Install searx plugin from repo to ~/.claude/plugins/searx/
# Run from the project root: .\install-plugin.ps1

$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$PluginDir = "$env:USERPROFILE\.claude\plugins\searx"

New-Item -ItemType Directory -Force -Path $PluginDir | Out-Null
Copy-Item -Path "$ScriptDir\plugin\*" -Destination $PluginDir -Recurse -Force

Write-Host "searx plugin installed to $PluginDir"
