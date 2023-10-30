using N64.Identity.Application.Common.Identity.Service;
using BC = BCrypt.Net.BCrypt;

namespace N64.Identity.Infrastructure.Common.Identity.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BC.HashPassword(password);
        }

        public bool ValidatePassword(string password, string hashedPassword)
        {
            return BC.Verify(password, hashedPassword);
        }
    }
}
