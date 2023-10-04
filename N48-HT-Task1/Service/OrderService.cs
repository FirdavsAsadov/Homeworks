using N48_HT_Task1.DataAccess;
using N48_HT_Task1.Models;
using N48_HT_Task1.Service.Interfeys;
using System.Linq.Expressions;

namespace N48_HT_Task1.Service
{
    public class OrderService : IOrderService
    {
        private readonly IDataContext _dataContext;
        public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await _dataContext.Orders.AddAsync(order, cancellationToken);

            if (saveChanges)
                await _dataContext.SaveChangesAsync();

            return user;
        }

        public ValueTask<Order> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Order> UpdateAsync(Order user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
