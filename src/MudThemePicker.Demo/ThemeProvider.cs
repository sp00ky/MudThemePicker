using MudBlazor;
using MudBlazor.Utilities;

namespace MudThemePicker.Demo;

public static class ThemeProvider
{
    public static IEnumerable<ThemeDefinition> GetThemes()
    {
        return new[]
        {
            new ThemeDefinition
            {
                Name = "Default",
                Description = "Default MudBlazor theme",
                Theme = new MudTheme()
            },
            new ThemeDefinition
            {
                Name = "Dark Mode",
                Description = "Dark theme with blue accent",
                Theme = new MudTheme
                {
                    PaletteLight = new PaletteLight
                    {
                        Primary = Colors.Blue.Default,
                        AppbarBackground = Colors.Blue.Default,
                    },
                    PaletteDark = new PaletteDark
                    {
                        Primary = Colors.Blue.Lighten1,
                        Surface = "#1e1e2e",
                        Background = "#1a1a27",
                        BackgroundGray = "#151521",
                        AppbarBackground = "#1e1e2e",
                        DrawerBackground = "#1e1e2e",
                        ActionDefault = "#adadb1",
                        ActionDisabled = "#52525e",
                        ActionDisabledBackground = "#52525e4d",
                    }
                }
            },
            new ThemeDefinition
            {
                Name = "Purple Haze",
                Description = "Purple and violet theme",
                Theme = new MudTheme
                {
                    PaletteLight = new PaletteLight
                    {
                        Primary = Colors.DeepPurple.Default,
                        Secondary = Colors.Purple.Accent2,
                        AppbarBackground = Colors.DeepPurple.Default,
                    }
                }
            },
            new ThemeDefinition
            {
                Name = "Green Forest",
                Description = "Nature-inspired green theme",
                Theme = new MudTheme
                {
                    PaletteLight = new PaletteLight
                    {
                        Primary = Colors.Green.Darken1,
                        Secondary = Colors.LightGreen.Accent3,
                        AppbarBackground = Colors.Green.Darken2,
                    }
                }
            },
            new ThemeDefinition
            {
                Name = "Sunset",
                Description = "Warm orange and red theme",
                Theme = new MudTheme
                {
                    PaletteLight = new PaletteLight
                    {
                        Primary = Colors.DeepOrange.Default,
                        Secondary = Colors.Orange.Accent2,
                        AppbarBackground = Colors.DeepOrange.Darken1,
                    }
                }
            },
            new ThemeDefinition
            {
                Name = "Ocean",
                Description = "Cool cyan and teal theme",
                Theme = new MudTheme
                {
                    PaletteLight = new PaletteLight
                    {
                        Primary = Colors.Cyan.Darken1,
                        Secondary = Colors.Teal.Accent2,
                        AppbarBackground = Colors.Cyan.Darken2,
                    }
                }
            }
        };
    }
}
