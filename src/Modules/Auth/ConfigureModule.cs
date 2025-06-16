using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.Modules.Auth.Interfaces.Services;
using Mono.Modules.Auth.Services;

namespace Mono.Modules.Auth;

public static class ConfigureModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddScoped<IRegistrationService, RegistrationService>();

        return services;
    }
}
