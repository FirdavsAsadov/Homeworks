using N53_Ht_Task1.api.Models;
using System.Linq.Expressions;

namespace N53_Ht_Task1.api.Interfeys
{
    public interface IUserService
    {
        IQueryable<User> Get(Expression<Func<User, bool>> predicate);
        ValueTask<User> CreateAsync(User user);
    }
}
