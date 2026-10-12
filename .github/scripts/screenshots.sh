#!/usr/bin/env bash
# CutProject: abre o app de verdade e captura as telas principais.
source "$(dirname "$0")/screenshots-common.sh"
"$APP" > "$OUT/app.log" 2>&1 &
APP_PID=$!
sleep 35
maximize "CutProject"
click 878 578; sleep 2          # "Not Now" no aviso do menu de aplicativos
shot inicio 2
click 162 24; shot menu-arquivo 2
key Escape; click 254 24; shot menu-clip 2
key Escape; click 322 24; shot menu-sequencia 2
key Escape; click 397 24; shot menu-efeitos 2
key Escape; sleep 1
click 105 122; shot painel-efeitos 2
click 176 122; shot painel-transicoes 2
click 46 122; sleep 1
key ctrl+comma; shot preferencias 3
key Escape; sleep 1
click 580 24; shot menu-ajuda 2
key Escape
finish
