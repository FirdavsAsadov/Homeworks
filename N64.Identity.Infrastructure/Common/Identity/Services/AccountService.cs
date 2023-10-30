using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.NotificationService;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    public static readonly List<User> _users = new();
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService  _emailOrchestrationService;
    public AccountService(IVerificationTokenGeneratorService verificationTokenGeneratorService, IEmailOrchestrationService emailOrchestrationService)
    {
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _emailOrchestrationService = emailOrchestrationService;
    }

    public List<User> Users => _users;
    public ValueTask<bool> VerificateAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token", nameof(token));

        var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

        if (!verificationTokenResult.isValid)
            throw new InvalidOperationException("Invalid verification token");

        var result = verificationTokenResult.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intented")
        };

        return result;
    }

    public ValueTask<User> CreateUserAsync(User user)
    {
        _users.Add(user);

        var emailVerification = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, user.Id);
        _emailOrchestrationService.SendAsync(user.Email, emailVerification);

        return new(user);
    }
    public ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        var foundUser = _users.FirstOrDefault(user => user.Id == userId) ?? throw new InvalidOperationException();

        foundUser.IsEmailAddressVerified = true;

        return new(true);
    }

}
