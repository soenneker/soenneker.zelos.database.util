using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.MemoryStream.Registrars;
using Soenneker.Zelos.Database.Util.Abstract;

namespace Soenneker.Zelos.Database.Util.Registrars;

/// <summary>
/// A DI utility that simplifies Zelos database access
/// </summary>
public static class ZelosDatabaseUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IZelosDatabaseUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddZelosDatabaseUtilAsSingleton(this IServiceCollection services)
    {
        services.AddMemoryStreamUtilAsSingleton().TryAddSingleton<IZelosDatabaseUtil, ZelosDatabaseUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IZelosDatabaseUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddZelosDatabaseUtilAsScoped(this IServiceCollection services)
    {
        services.AddMemoryStreamUtilAsSingleton().TryAddScoped<IZelosDatabaseUtil, ZelosDatabaseUtil>();

        return services;
    }
}