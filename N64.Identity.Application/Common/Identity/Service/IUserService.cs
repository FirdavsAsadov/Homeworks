using N64.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Application.Common.Identity.Service
{
    public interface IUserService
    {
        ValueTask<User> CreateUserAsync(User user);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> GetUserByIdAsync(Guid userId);
        IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    }
}
