﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.Settings;
using Newtonsoft.Json;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationCodeGeneratorService
{
    private readonly IDataProtector _protector;
    private readonly VerificationTokenSettings _verificationTokenSettings;
    public VerificationTokenGeneratorService(IDataProtectionProvider protector, IOptions<VerificationTokenSettings> verificationTokenSettings)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _protector = protector.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }

    public (VerificationCode Token, bool IsValid) DecodeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        var unprotectedToken = _protector.Unprotect(token);
        var verificationToken = JsonConvert.DeserializeObject<VerificationCode>(unprotectedToken) ??
                                throw new ArgumentNullException("Invalid verification Model", nameof(unprotectedToken));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }

    ValueTask<string> IVerificationCodeGeneratorService.GenerateCode(VerificationType verificationType, Guid userId)
    {
        var verificationToken = new VerificationCode
        {
            UserId = userId,
            Type = verificationType,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        };
        var result = _protector.Protect(JsonConvert.SerializeObject(verificationToken));
        return new(result);
    }
}
