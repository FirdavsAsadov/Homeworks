using N48_HT_Task1.Models;
using System.Linq.Expressions;

namespace N48_HT_Task1.Service.Interfeys
{
    public interface IOrderService
    {
        IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);

        ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

        ValueTask<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<Order> CreateAsync(Order user, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<Order> UpdateAsync(Order user, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<Order> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
