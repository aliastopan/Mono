using Mono.Modules.Auth.Entities;

namespace Mono.Modules.Auth.Interfaces.Services;

public interface IRegistrationService
{
    public User RegisterUser(string username, string emailAddress);
}
