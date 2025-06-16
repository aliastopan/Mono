using Mono.Modules.Auth.Interfaces.Services;

namespace Backend.Api.Endpoints.Auth;

public class RegistrationEndpoint : IEndpointDefinition
{
    public void DefineEndpoint(WebApplication app)
    {
        app.MapPost("/auth/user-registration/", RegisterUser);
    }

    internal string[] RegisterUser(RegistrationRequest request, IRegistrationService registrationService)
    {
        var user = registrationService.RegisterUser(request.Username, request.EmailAddress);

        return
        [
            user.UserId.ToString(),
            user.Username,
            user.EmailAddress
        ]; ;
    }
}

record RegistrationRequest(string Username, string EmailAddress);
