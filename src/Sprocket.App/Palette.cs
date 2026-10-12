using Avalonia.Media;
using Avalonia.Media.Immutable;

namespace Sprocket.App;

/// <summary>
/// The single source of truth for Sprocket's core color tokens (UI.md §1): near-black surfaces, a
/// neutral text ramp that clears WCAG AA, one accent (Project Club: coral #F87171), and the semantic status colors.
/// <para>
/// Both the XAML shell (<c>App.axaml</c>, via <c>{x:Static}</c>) and the custom-drawn Skia surfaces
/// (Timeline, Inspector, Media browser, keyframe lanes, stats overlay, dialogs) consume these, so the
/// palette can no longer drift between them. Before this existed the palette was copy-pasted into ~8
/// files and had already diverged — the accent was #4227a3 in the shell/dialogs but #6C5CE7 in every
/// drawn surface, and <see cref="FaintText"/> was a darker #6A7180 in the drawn surfaces that failed
/// AA at label sizes. Component-specific colors (clip fills, marker bands, lane stripes) stay local to
/// their control; only the genuinely shared tokens live here.
/// </para>
/// </summary>
public static class Palette
{
    // Surfaces, dark → raised.
    // Project Club: paleta escura compartilhada por todos os apps do ecossistema Project Club
    // (site, app desktop, launchers/editores). Mapeamento dos tokens:
    //   WindowBg  = #131417 (fundo da janela/diálogos/popups)
    //   PanelBg   = #1E1F24 (fundo primário dos painéis e campos de entrada)
    //   RaisedBg  = #343742 (botões/controles, cabeçalhos de painel, transport)
    //   SectionBg = #17181C (fundo secundário — cards do Inspector, um passo mais escuros que o painel)
    //   Edge      = #2E3038 (borda universal de 1px)
    // O tom mais profundo (#0E0F12) fica nas superfícies locais de timeline/monitor (TimelineControl,
    // PreviewSurface), que continuam definidas no próprio controle.
    public static readonly Color WindowBg = Color.Parse("#131417");
    public static readonly Color PanelBg = Color.Parse("#1E1F24");
    public static readonly Color RaisedBg = Color.Parse("#343742");
    public static readonly Color Edge = Color.Parse("#2E3038");

    // Text ramp. Every step clears 4.5:1 on the surfaces above at label sizes; FaintText is the AA-safe
    // floor (5.3:1 on PanelBg, 5.8:1 on SectionBg) — the drawn surfaces used to define it as #6A7180
    // (≈3.3:1), which failed.
    // Inspector section cards sit a step darker than the panel they float on (UI.md §3.5), and value
    // inputs carry a visibly lighter grey border than Edge so they read as editable fields on that
    // darker card (Edge at 1px on SectionBg is nearly invisible).
    // Project Club: texto primário #F0F5FA e secundário #A9AEBB da paleta compartilhada. A borda
    // secundária da paleta (#3A3D47) quase some sobre SectionBg, então InputEdge usa um cinza mais claro
    // na mesma família para os campos editáveis continuarem visíveis.
    public static readonly Color SectionBg = Color.Parse("#17181C");
    public static readonly Color InputEdge = Color.Parse("#5A5E6B");

    public static readonly Color Text = Color.Parse("#F0F5FA");
    public static readonly Color MutedText = Color.Parse("#A9AEBB");
    public static readonly Color FaintText = Color.Parse("#8E93A0");

    // One accent, used both as a fill (primary buttons, menu/list hover, Play) and as a 1–2px indicator
    // line on the dark surfaces (playhead, selection outline, keyframes).
    // Project Club: o acento deste app (CutProject) é o vermelho coral #F87171. Branco sobre o coral
    // dá só ~2.8:1 (reprova AA), então o texto/ícone sobre preenchimentos de acento passou a usar
    // OnAccent (quase preto, ~6.7:1). Com texto escuro o hover precisa CLAREAR — AccentHover é o coral
    // claro #FCA5A5 (~9.7:1 com OnAccent). O coral escuro da paleta (#DC2626) fica na rampa do
    // SystemAccentColor do Fluent (App.axaml).
    public static readonly Color Accent = Color.Parse("#F87171");
    public static readonly Color AccentHover = Color.Parse("#FCA5A5");
    public static readonly Color OnAccent = Color.Parse("#131417");
    // Project Club: o coral como TEXTO dá 4.3:1 sobre RaisedBg (#343742), abaixo do piso AA. Texto em
    // cor de acento sobre RaisedBg (linhas de fila/cards, categoria de efeito) usa o coral claro (~6.2:1).
    public static readonly Color AccentText = Color.Parse("#FCA5A5");

    // Semantic status — status-bar state dot + playback-stats health readout.
    // Project Club: Bad era #F85149, praticamente igual ao coral do acento. Passou para um carmim bem
    // saturado puxado ao rosa (#FF2D55), para erro/clip dos medidores não se confundir com o acento.
    public static readonly Color Good = Color.Parse("#3FB950");
    public static readonly Color Warn = Color.Parse("#D29922");
    public static readonly Color Bad = Color.Parse("#FF2D55");

    // Destructive action (window close-button hover).
    public static readonly Color Danger = Color.Parse("#C0392B");

    // Shared immutable brushes for the custom-drawn surfaces. ImmutableSolidColorBrush is safe to reuse
    // across every draw — this is what lets the drawing hot path stay allocation-free (ARCHITECTURE §1).
    public static readonly IBrush WindowBgBrush = new ImmutableSolidColorBrush(WindowBg);
    public static readonly IBrush PanelBgBrush = new ImmutableSolidColorBrush(PanelBg);
    public static readonly IBrush RaisedBgBrush = new ImmutableSolidColorBrush(RaisedBg);
    public static readonly IBrush SectionBgBrush = new ImmutableSolidColorBrush(SectionBg);
    public static readonly IBrush EdgeBrush = new ImmutableSolidColorBrush(Edge);
    public static readonly IBrush InputEdgeBrush = new ImmutableSolidColorBrush(InputEdge);
    public static readonly IBrush TextBrush = new ImmutableSolidColorBrush(Text);
    public static readonly IBrush MutedTextBrush = new ImmutableSolidColorBrush(MutedText);
    public static readonly IBrush FaintTextBrush = new ImmutableSolidColorBrush(FaintText);
    public static readonly IBrush AccentBrush = new ImmutableSolidColorBrush(Accent);
    public static readonly IBrush OnAccentBrush = new ImmutableSolidColorBrush(OnAccent);
    public static readonly IBrush AccentTextBrush = new ImmutableSolidColorBrush(AccentText);
    public static readonly IBrush GoodBrush = new ImmutableSolidColorBrush(Good);
    public static readonly IBrush WarnBrush = new ImmutableSolidColorBrush(Warn);
    public static readonly IBrush BadBrush = new ImmutableSolidColorBrush(Bad);
}
