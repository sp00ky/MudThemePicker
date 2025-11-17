namespace MudThemePicker;

/// <summary>
/// Service for managing application themes
/// </summary>
public class ThemeService
{
    private ThemeDefinition? _currentTheme;
    private IEnumerable<ThemeDefinition>? _availableThemes;
    
    /// <summary>
    /// Event raised when the theme changes
    /// </summary>
    public event EventHandler<ThemeDefinition>? ThemeChanged;

    /// <summary>
    /// Gets the currently active theme
    /// </summary>
    public ThemeDefinition? CurrentTheme => _currentTheme;

    /// <summary>
    /// Gets or sets the collection of available themes
    /// </summary>
    public IEnumerable<ThemeDefinition>? AvailableThemes
    {
        get => _availableThemes;
        set => _availableThemes = value;
    }

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
