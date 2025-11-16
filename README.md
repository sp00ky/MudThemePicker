# MudThemePicker

A theme picker component for MudBlazor applications that allows users to discover and switch between multiple themes dynamically.

## Features

- 🎨 **Dynamic Theme Switching** - Switch between themes on the fly without reloading the page
- 🔍 **Automatic Theme Discovery** - Drop in new `MudTheme` classes and have them show up instantly
- 🎯 **Simple Integration** - Just a few lines of code to add to your MudBlazor app
- 💡 **Customizable Themes** - Define your own custom themes with MudBlazor's theming system

## Installation

1. Add the MudThemePicker library to your project:
```bash
dotnet add package MudThemePicker
```

2. Add MudBlazor and MudThemePicker services in your `Program.cs`:
```csharp
using MudBlazor.Services;
using MudThemePicker;

builder.Services.AddMudServices();
builder.Services.AddMudThemePicker();
```

3. Add the required imports to your `_Imports.razor`:
```razor
@using MudBlazor
@using global::MudThemePicker
```

## Usage

### 1. Define Your Themes

Create `MudTheme` subclasses anywhere in your project. The class name is automatically converted into a readable label (camel casing with the `Theme` suffix removed) and you can opt-in to descriptions with `DescriptionAttribute`.

```csharp
using System.ComponentModel;
using MudBlazor;

[Description("Default MudBlazor look and feel")]
public class DefaultTheme : MudTheme
{
    public DefaultTheme()
    {
        PaletteLight = new PaletteLight
        {
            Primary = Colors.Blue.Default,
        };
    }
}

public class DarkModeTheme : MudTheme
{
    public DarkModeTheme()
    {
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Blue.Lighten1,
            Surface = "#1e1e2e",
            Background = "#1a1a27",
        };
    }
}
```

To expose these themes to the picker call `ThemeDiscovery` once at startup (or wrap it the way that works best for your app):

```csharp
var themes = ThemeDiscovery.DiscoverThemes(typeof(DefaultTheme).Assembly);
```

### 2. Wrap Your App with ThemePickerProvider

In your `App.razor`, wrap your router with the `ThemePickerProvider`:

```razor
@using global::MudThemePicker

<ThemePickerProvider DefaultTheme="@_defaultTheme">
    <Router AppAssembly="@typeof(App).Assembly">
        <!-- Your router content -->
    </Router>
</ThemePickerProvider>

@code {
    private global::MudThemePicker.ThemeDefinition _defaultTheme = ThemeDiscovery
        .DiscoverThemes(typeof(DefaultTheme).Assembly)
        .First();
}
```

### 3. Add the Theme Picker Component

Add the `ThemePicker` component anywhere in your layout (e.g., in the app bar):

```razor
@using global::MudThemePicker

<MudAppBar>
    <MudText Typo="Typo.h5">My App</MudText>
    <MudSpacer />
    <ThemePicker Themes="@ThemeDiscovery.DiscoverThemes(typeof(DefaultTheme).Assembly)" />
</MudAppBar>
```

## Demo Application

Check out the included demo application in the `src/MudThemePicker.Demo` folder to see a complete working example.

To run the demo:

```bash
cd src/MudThemePicker.Demo
dotnet run
```

## API Reference

### ThemeDefinition

Represents a named theme definition.

| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | The name of the theme |
| `Theme` | `MudTheme` | The MudBlazor theme object |
| `Description` | `string?` | Optional description for the theme |

### ThemePickerProvider

Provider component that wraps your application and manages theme switching.

| Parameter | Type | Description |
|-----------|------|-------------|
| `DefaultTheme` | `ThemeDefinition?` | The default theme to use on startup |
| `ChildContent` | `RenderFragment?` | The child content to render |

### ThemePicker

The theme picker dropdown component.

| Parameter | Type | Description |
|-----------|------|-------------|
| `Themes` | `IEnumerable<ThemeDefinition>?` | Collection of available themes |

### ThemeDiscovery

Helpers for turning `MudTheme` subclasses into `ThemeDefinition` instances that the picker can display.

| Method | Description |
|--------|-------------|
| `DiscoverThemes(params Assembly[] assemblies)` | Scans the supplied assemblies for `MudTheme` subclasses, creates instances, infers friendly names from the class name, and uses any `DescriptionAttribute` value as the description. |

### ThemeService

Injectable service for theme management.

| Property | Type | Description |
|----------|------|-------------|
| `CurrentTheme` | `ThemeDefinition?` | Gets the currently active theme |

| Method | Description |
|--------|-------------|
| `SetTheme(ThemeDefinition)` | Sets the current theme and raises the ThemeChanged event |

| Event | Description |
|-------|-------------|
| `ThemeChanged` | Event raised when the theme changes |

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
