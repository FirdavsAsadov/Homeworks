using N64.Identity.Domain.Entities;

namespace N64.Identity.Application.Common.Identity.Service;

public interface IAccountService
{
    ValueTask<bool> VerificateAsync(string token);

    ValueTask<User> CreateUserAsync(User user);
    ValueTask<User> UpdateUserAsync(User user);
}
