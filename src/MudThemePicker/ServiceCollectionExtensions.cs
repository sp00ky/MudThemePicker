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
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddMudThemePicker(this IServiceCollection services)
    {
        services.AddSingleton<ThemeService>();
        return services;
    }
}
