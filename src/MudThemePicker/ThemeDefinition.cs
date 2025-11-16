using MudBlazor;

namespace MudThemePicker;

/// <summary>
/// Represents a named theme definition
/// </summary>
public class ThemeDefinition
{
    /// <summary>
    /// Gets or sets the name of the theme
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the MudBlazor theme
    /// </summary>
    public MudTheme Theme { get; set; } = new();

    /// <summary>
    /// Gets or sets an optional description for the theme
    /// </summary>
    public string? Description { get; set; }
}
