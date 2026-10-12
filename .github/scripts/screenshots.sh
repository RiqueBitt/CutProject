#!/usr/bin/env bash
# CutProject: abre o app de verdade e captura as telas principais.
source "$(dirname "$0")/screenshots-common.sh"
"$APP" > "$OUT/app.log" 2>&1 &
APP_PID=$!
sleep 35
maximize "CutProject"
shot inicio 3
key alt+f; shot menu-arquivo 2
key Escape; key alt+e; shot menu-editar 2
key Escape; key alt+v; shot menu-ver 2
key Escape; key alt+h; shot menu-ajuda 2
key Escape; key ctrl+comma; shot preferencias 3
key Escape; key ctrl+i; shot importar 3
key Escape; key ctrl+m; shot exportar 3
key Escape
finish
