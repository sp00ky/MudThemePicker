using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using MudBlazor;

namespace MudThemePicker;

/// <summary>
/// Helpers for discovering <see cref="MudTheme"/> implementations and converting them to <see cref="ThemeDefinition"/>s.
/// </summary>
public static class ThemeDiscovery
{
    private static readonly Regex _camelCaseRegex = new("(?<=[a-z0-9])([A-Z])", RegexOptions.Compiled);

    /// <summary>
    /// Discovers themes from the provided assemblies. If no assemblies are provided, the calling assembly is inspected.
    /// </summary>
    /// <param name="assemblies">Assemblies that contain custom <see cref="MudTheme"/> types.</param>
    /// <returns>An enumerable collection of <see cref="ThemeDefinition"/> instances.</returns>
    public static IEnumerable<ThemeDefinition> DiscoverThemes(params Assembly[] assemblies)
    {
        var assembliesToScan = (assemblies?.Length > 0 ? assemblies : new[] { Assembly.GetCallingAssembly() })
            .Where(a => a != null)
            .Distinct();

        var discovered = new List<ThemeDefinition>();

        foreach (var assembly in assembliesToScan)
        {
            IEnumerable<Type?> types;

            try
            {
                types = assembly!.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                types = ex.Types.Where(t => t != null);
            }

            foreach (var type in types)
            {
                if (type is null)
                {
                    continue;
                }

                if (type.IsAbstract || !typeof(MudTheme).IsAssignableFrom(type))
                {
                    continue;
                }

                if (Activator.CreateInstance(type) is not MudTheme theme)
                {
                    continue;
                }

                discovered.Add(new ThemeDefinition
                {
                    Name = GetDisplayName(type),
                    Description = type.GetCustomAttribute<DescriptionAttribute>()?.Description,
                    Theme = theme,
                });
            }
        }

        return discovered
            .OrderBy(t => t.Name, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    private static string GetDisplayName(Type type)
    {
        var name = type.Name;

        if (name.EndsWith("theme", StringComparison.OrdinalIgnoreCase))
        {
            name = name[..^5];
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            name = type.Name;
        }

        var withSpaces = _camelCaseRegex.Replace(name, " $1").Trim();

        return string.IsNullOrWhiteSpace(withSpaces) ? type.Name : withSpaces;
    }
}
