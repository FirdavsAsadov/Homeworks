using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContext;
using System.Linq.Expressions;

namespace N64.Identity.Infrastructure.Common.Identity.Services
{
    public class VerificationCodeService : IVerificationCodeService
    {
        private readonly AppDbContext _appDbContext;
        private readonly VerificationCodeSettings _verificationCodeSettings;

        public VerificationCodeService(AppDbContext appDbContext, IOptions<VerificationCodeSettings> verificationCodeSettings)
        {
            _appDbContext = appDbContext;
            
            _verificationCodeSettings = verificationCodeSettings.Value;
        }

        public async ValueTask<string> Generate(Guid userId)
        {

            var verification = new VerificationCode
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ExpiryTime = DateTime.UtcNow.AddMinutes(_verificationCodeSettings.IdentityVerificationCodeExpirationDurationInMinutes),
                Code = new Random().Next(1000, 99999).ToString()
            };

            var createdCode = await CreateAsync(verification);

            return new(createdCode.Code);
        }

        public async ValueTask<VerificationCode> CreateAsync(VerificationCode code)
        {
            _appDbContext.VerificationCodes.Add(code);
            await _appDbContext.SaveChangesAsync();
            return code;
        }

        public IQueryable<VerificationCode> Get(Expression<Func<VerificationCode, bool>> predicate)
            => _appDbContext.VerificationCodes.Where(predicate.Compile()).AsQueryable();

        public async ValueTask<VerificationCode> UpdateAsync(VerificationCode code)
        {
            var updatingCode = _appDbContext.VerificationCodes.FirstOrDefault(x => x.Code == code.Code);
            if (updatingCode == null)
                throw new InvalidOperationException("This Code Already exsisting!");

            var newCode = new VerificationCode
            {
                Id= code.Id,
                UserId = code.UserId,
                Code = new Random().Next(1000, 99999).ToString(),
                ExpiryTime = DateTime.UtcNow.AddMinutes(_verificationCodeSettings.IdentityVerificationCodeExpirationDurationInMinutes)
            };

            _appDbContext.Add(newCode);
            await _appDbContext.SaveChangesAsync();
            return newCode;
        }
    }
}
