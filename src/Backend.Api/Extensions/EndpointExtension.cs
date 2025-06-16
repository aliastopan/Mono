using System.Reflection;

namespace Backend.Api.Extensions;

internal static class EndpointExtension
{
    internal static IServiceCollection AddEndpointDefinitions(this IServiceCollection services)
    {
        var endpoints = new List<IEndpointDefinition>();

        // scans the executing assembly for any IEndpointDefinition implementation
        endpoints.AddRange(Assembly.GetExecutingAssembly().ExportedTypes
            .Where(target => typeof(IEndpointDefinition).IsAssignableFrom(target) && !target.IsInterface && !target.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IEndpointDefinition>()
        );

        services.AddSingleton(endpoints as IReadOnlyCollection<IEndpointDefinition>);
        return services;
    }

    internal static WebApplication UseEndpointDefinitions(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
        foreach (var endpoint in endpoints)
        {
            endpoint.DefineEndpoint(app);
        }

        return app;
    }
}
