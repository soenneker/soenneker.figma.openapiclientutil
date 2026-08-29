using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Figma.HttpClients.Registrars;
using Soenneker.Figma.OpenApiClientUtil.Abstract;

namespace Soenneker.Figma.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class FigmaOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="FigmaOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddFigmaOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddFigmaOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IFigmaOpenApiClientUtil, FigmaOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="FigmaOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddFigmaOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddFigmaOpenApiHttpClientAsSingleton()
                .TryAddScoped<IFigmaOpenApiClientUtil, FigmaOpenApiClientUtil>();

        return services;
    }
}
