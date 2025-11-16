using MudBlazor;

namespace MudThemePicker;

/// <summary>
/// Service for managing application themes
/// </summary>
public class ThemeService
{
    private ThemeDefinition? _currentTheme;
    
    /// <summary>
    /// Event raised when the theme changes
    /// </summary>
    public event EventHandler<ThemeDefinition>? ThemeChanged;

    /// <summary>
    /// Gets the currently active theme
    /// </summary>
    public ThemeDefinition? CurrentTheme => _currentTheme;

    /// <summary>
    /// Sets the current theme and raises the ThemeChanged event
    /// </summary>
    /// <param name="theme">The theme to set as current</param>
    public void SetTheme(ThemeDefinition theme)
    {
        _currentTheme = theme;
        ThemeChanged?.Invoke(this, theme);
    }
}
