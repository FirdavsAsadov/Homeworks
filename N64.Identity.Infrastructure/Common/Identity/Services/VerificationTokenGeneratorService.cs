using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.Settings;
using Newtonsoft.Json;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _protector;
    private readonly VerificationTokenSettings _verificationTokenSettings;
    public VerificationTokenGeneratorService(IDataProtectionProvider protector, IOptions<VerificationTokenSettings> verificationTokenSettings)
    {
        _protector = protector.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
        _verificationTokenSettings = verificationTokenSettings.Value;
    }

    public (VerificationToken Token, bool isValid) DecodeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        var unprotectedToken = _protector.Unprotect(token);
        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unprotectedToken) ??
                                throw new ArgumentNullException("Invalid verification Model", nameof(unprotectedToken));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }

    public string GenerateToken(VerificationType type, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        };
        return _protector.Protect(JsonConvert.SerializeObject(verificationToken));
    }
}
