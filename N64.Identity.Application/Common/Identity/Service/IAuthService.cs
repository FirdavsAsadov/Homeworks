using N64.Identity.Application.Common.Identity.Models;

namespace N64.Identity.Application.Common.Identity.Service;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);
    ValueTask<string> LoginAsync(LoginDetails loginDetails);
}
