using MudThemePicker.WasmDemo.Client.Themes;

namespace MudThemePicker.WasmDemo.Client;

/// <summary>
/// Provides the set of discoverable themes for the WASM demo.
/// </summary>
public static class ThemeProvider
{
    private static readonly Lazy<ThemeDefinition[]> _themes = new(() =>
        ThemeDiscovery.DiscoverThemes(typeof(DefaultTheme).Assembly).ToArray());

    /// <summary>
    /// Gets the available themes to display in the picker.
    /// </summary>
    public static IReadOnlyList<ThemeDefinition> Themes => _themes.Value;

    /// <summary>
    /// Gets the default theme used when the app loads.
    /// </summary>
    public static ThemeDefinition DefaultTheme => _themes.Value.First();
}
