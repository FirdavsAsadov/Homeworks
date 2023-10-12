using N52_ht_Task_1.Models;
using System.Linq.Expressions;

namespace N52_ht_Task_1.Services.Interfeys
{
    public interface IUserService
    {
        IQueryable<User> Get(Expression<Func<User, bool>> predicate);
        ValueTask<User> CreateAsync(User user);
    }
}
