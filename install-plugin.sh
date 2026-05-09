#!/bin/bash
# Install searx plugin from repo to ~/.claude/plugins/searx/
# Run from the project root: ./install-plugin.sh

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
PLUGIN_DIR="$HOME/.claude/plugins/searx"

mkdir -p "$PLUGIN_DIR"
cp -r "$SCRIPT_DIR/plugin/." "$PLUGIN_DIR/"

echo "searx plugin installed to $PLUGIN_DIR"
