namespace N64.Identity.Application.Common.Identity.Service
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool ValidatePassword(string password, string hashedPassword);
    }
}
