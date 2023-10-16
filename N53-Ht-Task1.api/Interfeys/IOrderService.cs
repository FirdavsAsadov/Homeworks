using N53_Ht_Task1.api.Models;
using System.Linq.Expressions;

namespace N53_Ht_Task1.api.Interfeys
{
    public interface IOrderService
    {
        IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);
        ValueTask<Order> CreateAsync(Order order);
    }
}
