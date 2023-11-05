using System.Linq.Expressions;
using N67.Domain_.Entities;

namespace EduCourse.Application.Common.Identity.Services
{
    public interface IUserService
    {
        IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null);
        ValueTask<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<User> DeleteAsync(Guid userId, bool saveChanges = true,
            CancellationToken cancellationToken = default);
    }
}