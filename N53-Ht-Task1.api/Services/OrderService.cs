using N53_Ht_Task1.api.DataAccess;
using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;
using System.Linq.Expressions;

namespace N53_Ht_Task1.api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDataContext  _context;

        public OrderService(IDataContext context)
        {
            _context = context;
        }

        public async ValueTask<Order> CreateAsync(Order order)
        {
            var result = await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
             => _context.Orders.Where(predicate.Compile()).AsQueryable();
    }
}
