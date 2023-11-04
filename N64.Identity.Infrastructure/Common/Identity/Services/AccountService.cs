using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.NotificationService;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContext;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationCodeGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService  _emailOrchestrationService;
    private readonly IUserService _userService;
    private readonly AppDbContext  _appDbContext;
    public AccountService(IVerificationCodeGeneratorService verificationTokenGeneratorService, IEmailOrchestrationService emailOrchestrationService, IUserService userService, AppDbContext appDbContext)
    {
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _emailOrchestrationService = emailOrchestrationService;
        _userService = userService;
        _appDbContext = appDbContext;
    }
    public ValueTask<bool> VerificateAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token", nameof(token));

        var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

        if (!verificationTokenResult.IsValid)
            throw new InvalidOperationException("Invalid verification token");

        var result = verificationTokenResult.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intented")
        };

        return result;
    }

    public async ValueTask<User> CreateUserAsync(User user)
    {
        await _userService.CreateUserAsync(user);

        var emailVerification = _verificationTokenGeneratorService.GenerateCode(VerificationType.EmailAddressVerification, user.Id = Guid.Empty);
        await _emailOrchestrationService.SendVerificationCodeAsync(user.Email, emailVerification.ToString());

        return user;
    }

    public ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        var foundUser = _appDbContext.Users.FirstOrDefault(user => user.Id == userId) ?? throw new InvalidOperationException();

        foundUser.IsEmailAddressVerified = true;

        return new(true);
    }

    public async ValueTask<User> UpdateUserAsync(User user)
    {
        await _userService.UpdateUserAsync(user);
        var emailVerification = _verificationTokenGeneratorService.GenerateCode(VerificationType.EmailAddressVerification, user.Id = Guid.Empty);
        await _emailOrchestrationService.SendVerificationCodeAsync(user.Email, emailVerification.ToString());
        return user;
    }
}
