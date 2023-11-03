using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Persistence.DataContext;
using Newtonsoft.Json;

namespace N64.Identity.Infrastructure.Common.Identity.Services
{
    public class VerificationCodeGeneratorService : IVerificationCodeGeneratorService
    {
        private readonly AppDbContext _appDbContext;
        private readonly VerificationTokenSettings _verificationTokenSettings;

        public VerificationCodeGeneratorService(AppDbContext appDbContext, IOptions<VerificationTokenSettings> verificationTokenSettings)
        {
            _appDbContext = appDbContext;
            _verificationTokenSettings = verificationTokenSettings.Value;
        }

        public async ValueTask<string> GenerateCode(VerificationType verificationType, Guid userId)
        {
            var verificationCode = new VerificationCode
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = verificationType,
                ExpiryTime = DateTime.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes),
                Code = new Random().Next(1000, 99999).ToString()
            };
            await _appDbContext.VerificationCodes.AddAsync(verificationCode);
            await _appDbContext.SaveChangesAsync();
            return verificationCode.Code;
        }

        public (VerificationCode Token, bool IsValid) DecodeToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(token);

            var verificationCode = JsonConvert.DeserializeObject<VerificationCode>(token) ??
                        throw new ArgumentNullException("Invalid Verification token", nameof(token));

            return (verificationCode, verificationCode.ExpiryTime > DateTimeOffset.UtcNow);

        }
    }
}
