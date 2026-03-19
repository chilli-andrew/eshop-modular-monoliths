using System.Reflection;
using Carter;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions;

public static class CaterExtensions
{
    public static IServiceCollection AddCaterWithAssemblies(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        services.AddCarter(configurator: config =>
        {
            foreach (var assembly in assemblies)
            {
                var modules = assembly.GetTypes()
                    .Where(t => t.IsAssignableFrom(typeof(ICarterModule))).ToArray();
                config.WithModules(modules);
            }

        });
        return services;
    }
}