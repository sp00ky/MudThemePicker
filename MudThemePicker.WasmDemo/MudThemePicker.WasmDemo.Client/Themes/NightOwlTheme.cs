using System.ComponentModel;
using MudBlazor;

namespace MudThemePicker.WasmDemo.Client.Themes;

/// <summary>
/// A dark, high-contrast theme inspired by code editors.
/// </summary>
[Description("Dark, high-contrast palette for low light environments")]
public class NightOwlTheme : MudTheme
{
    public NightOwlTheme()
    {
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Blue.Accent2,
            Secondary = Colors.Green.Accent3,
            Background = "#0b1021",
            Surface = "#11172a",
            DrawerBackground = "#0b1021",
            AppbarBackground = "#0d1326",
        };

        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "6px",
        };
    }
}
