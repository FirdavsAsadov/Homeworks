using N53_Ht_Task1.api.Models;
using System.Linq.Expressions;

namespace N53_Ht_Task1.api.Interfeys
{
    public interface IBonusService
    {
        IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate);
        ValueTask<Bonus> CreateAsync(Bonus bonus);
        ValueTask<Bonus> UpdateAsync(Bonus bonus);
    }
}
