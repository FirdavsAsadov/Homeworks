using N64.Identity.Domain.Entities;

namespace N64.Identity.Application.Common.Identity.Service;

public interface IAccountService
{
    List<User> Users { get; }

    ValueTask<bool> VerificateAsync(string token);

    ValueTask<User> CreateUserAsync(User user);
}
