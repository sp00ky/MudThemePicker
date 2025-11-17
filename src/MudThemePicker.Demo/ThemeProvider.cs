using MudThemePicker.Demo.Themes;

namespace MudThemePicker.Demo;

public static class ThemeProvider
{
    private static readonly Lazy<IEnumerable<ThemeDefinition>> _themes = new(() =>
        ThemeDiscovery.DiscoverThemes(typeof(FedExTheme).Assembly).ToArray());

    public static IEnumerable<ThemeDefinition> GetThemes() => _themes.Value;
}
