using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Infrastructure.Common.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAccessTokenGeneratorService _accessTokenGeneratorService;
        private readonly VerificationTokenSettings  _verificationTokenSettings;
        public TokenService(AppDbContext appDbContext, IAccessTokenGeneratorService accessTokenGeneratorService, IOptions<VerificationTokenSettings> verificationTokenSettings)
        {
            _appDbContext = appDbContext;
            _accessTokenGeneratorService = accessTokenGeneratorService;
            _verificationTokenSettings = verificationTokenSettings.Value;
        }

        public async ValueTask<string> Generate(User user)
        {
            var accessToken = _accessTokenGeneratorService.GetToken(user);

            var token = new Token
            {
                UserId = user.Id,
                TokenValue = accessToken,
                ExpiryTime = DateTime.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
            };

            var createdToken = await CreateTokenAsync(token);
            return createdToken.TokenValue;
        }

        public async ValueTask<Token> CreateTokenAsync(Token token)
        {
            _appDbContext.Tokens.Add(token);
            await _appDbContext.SaveChangesAsync();
            return token;
        }

        public IQueryable<Token> Get(Expression<Func<Token, bool>> predicate)
            => _appDbContext.Tokens.Where(predicate.Compile()).AsQueryable();
        public ValueTask<Token> GetTokenByIdAsync(Guid tokenId)
        {
            var foundingToken = _appDbContext.Tokens.FirstOrDefault(x => x.Id == tokenId);
            if (foundingToken == null)
                throw new InvalidOperationException("this token does not exsist!!");

            return new(foundingToken);
        }

        public async ValueTask<Token> UpdateTokenAsync(Token token)
        {
            var updatingToken = _appDbContext.Tokens.FirstOrDefault(x => x.Id == token.Id);
            if (updatingToken == null)
                throw new InvalidOperationException("This token does not exsist!!");

            var newToken = new Token
            {
                Id = token.Id,
                UserId = token.UserId,
                TokenValue = token.TokenValue,
                ExpiryTime = DateTime.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
            };
            _appDbContext.Add(newToken);
            await _appDbContext.SaveChangesAsync();
            return newToken;
        }
    }
}
