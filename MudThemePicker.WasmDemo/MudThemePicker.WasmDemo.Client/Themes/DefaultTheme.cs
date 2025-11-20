using MudBlazor;

namespace MudThemePicker.WasmDemo.Client.Themes;

/// <summary>
/// A clean light theme that keeps the default MudBlazor palette.
/// </summary>
public class DefaultTheme : MudTheme
{
    public DefaultTheme()
    {
        PaletteLight = new PaletteLight
        {
            Primary = Colors.Blue.Default,
            Secondary = Colors.DeepPurple.Accent2,
        };
    }
}
