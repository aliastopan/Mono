using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mono.Modules.Auth;

public static class ConfigureModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration cfg)
    {
        return services;
    }
}
