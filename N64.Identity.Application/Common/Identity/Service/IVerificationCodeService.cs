using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N64.Identity.Application.Common.Identity.Service
{
    public interface IVerificationCodeService
    {
        ValueTask<string> Generate(Guid userId);
        ValueTask<VerificationCode> CreateAsync(VerificationCode code);
        ValueTask<VerificationCode> UpdateAsync(VerificationCode code);
        IQueryable<VerificationCode> Get(Expression<Func<VerificationCode, bool>> predicate);

    }
}
