using N64.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Application.Common.Identity.Service
{
    public interface ITokenService
    {
        ValueTask<string> Generate(User user);
        ValueTask<Token> CreateTokenAsync(Token token);
        ValueTask<Token> UpdateTokenAsync(Token token);
        ValueTask<Token> GetTokenByIdAsync(Guid tokenId);
        IQueryable<Token> Get(Expression<Func<Token, bool>> predicate);
    }
}
