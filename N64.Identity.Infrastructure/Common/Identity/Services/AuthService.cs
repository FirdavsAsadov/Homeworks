using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.NotificationService;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContext;
using System.Security.Authentication;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private IPasswordHasher _passwordHasherService;
    private IAccountService  _accountService;
    private readonly AppDbContext  _appDbContext;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    public AuthService(IPasswordHasher passwordHasherService, IAccountService accountService, IEmailOrchestrationService emailOrchestrationService, ITokenService tokenService, AppDbContext appDbContext)
    {
        _passwordHasherService = passwordHasherService;
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
        _tokenService = tokenService;
        _appDbContext = appDbContext;
    }

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var foundUser = _appDbContext.Users.FirstOrDefault(user => user.Email == registrationDetails.Email);
        if (foundUser != null)
            throw new InvalidOperationException("This User Alreday exsisting!!");

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Email = registrationDetails.Email,
            Password = _passwordHasherService.HashPassword(registrationDetails.Password)
        };

        await _accountService.CreateUserAsync(newUser);
        var verificationEmailResult = await _emailOrchestrationService.SendAsync(registrationDetails.Email, "sistemaga xush kelibsiz");

        return true;
    }
    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var founderUser = _appDbContext.Users.FirstOrDefault(x => x.Email == loginDetails.Email);
        if (founderUser == null)
            throw new AuthenticationException("Login details are invalid!!");

        var accessToken = _tokenService.Generate(founderUser);
        return accessToken;
    }
}
