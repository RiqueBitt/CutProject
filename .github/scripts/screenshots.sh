#!/usr/bin/env bash
# CutProject: abre o app de verdade, carrega o projeto de exemplo e captura
# as telas principais.
source "$(dirname "$0")/screenshots-common.sh"
"$APP" > "$OUT/app.log" 2>&1 &
APP_PID=$!
sleep 35
maximize "CutProject"
click 878 578; sleep 2                  # "Not Now" no aviso do menu de aplicativos
click 162 24; sleep 1; click 215 107    # Arquivo ▸ Abrir projeto de exemplo
sleep 10; shot projeto-de-exemplo 2
key space; sleep 3; shot reproduzindo 1
key space; sleep 1
click 300 612; shot clipe-selecionado 3  # seleciona um clipe na linha do tempo
click 162 24; shot menu-arquivo 2
key Escape; click 254 24; shot menu-clip 2
key Escape; click 397 24; shot menu-efeitos 2
key Escape; sleep 1
click 105 122; shot painel-efeitos 2
click 176 122; shot painel-transicoes 2
click 46 122; sleep 1
key ctrl+e; shot exportar 4
key Escape; sleep 1
click 322 24; shot menu-sequencia 2
key Escape; click 518 24; shot menu-janela 2
key Escape
finish
# A janela do CutProject abre em 1282x802 (não ocupa a tela toda): recorta
# só a janela e amplia para 1600x1000, sem a borda preta.
for f in "$OUT"/*.png; do
  convert "$f" -crop 1282x802+8+8 +repage -resize 1600x1000\! "$f"
done
