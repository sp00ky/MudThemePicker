using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MudThemePicker;

/// <summary>
/// Extension methods for IServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the MudThemePicker services to the service collection
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="assembliesToScan">Optional assemblies to scan for themes. If not provided, the calling assembly will be scanned.</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddMudThemePicker(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
        services.AddSingleton<ThemeService>(sp =>
        {
            var themeService = new ThemeService();
            
            // Discover themes from the specified assemblies or the calling assembly
            var assemblies = assembliesToScan?.Length > 0 
                ? assembliesToScan 
                : new[] { Assembly.GetCallingAssembly() };
            
            var discoveredThemes = ThemeDiscovery.DiscoverThemes(assemblies);
            themeService.AvailableThemes = discoveredThemes;
            
            return themeService;
        });
        
        return services;
    }
}
