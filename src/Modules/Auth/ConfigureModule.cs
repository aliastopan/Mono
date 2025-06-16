using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.Modules.Auth.Data;
using Mono.Modules.Auth.Interfaces.Services;
using Mono.Modules.Auth.Services;

namespace Mono.Modules.Auth;

public static class ConfigureModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddScoped<IRegistrationService, RegistrationService>();

        services.AddDbContext<AuthDbContext>(option =>
        {
            var connectionString = cfg.GetConnectionString("DefaultConnection");
            var serverVersion = new MariaDbServerVersion(new Version(11, 8, 22));
            option.UseMySql(connectionString, serverVersion);
        });

        return services;
    }
}
