using Mono.Modules.Auth.Entities;
using Mono.Modules.Auth.Interfaces.Services;

namespace Mono.Modules.Auth.Services;

internal sealed class RegistrationService : IRegistrationService
{
    public User RegisterUser(string username, string emailAddress)
    {
        return new User()
        {
            UserId = Guid.CreateVersion7(),
            Username = username,
            EmailAddress = emailAddress
        };
    }
}
