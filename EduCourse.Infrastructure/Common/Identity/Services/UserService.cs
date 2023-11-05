using System.Linq.Expressions;
using EduCourse.Application.Common.Identity.Services;
using N67.Domain_.Entities;

namespace EduCourse.Infrastructure.Common.Identity.Services
{
    public class UserService : IUserService
    {
        public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> DeleteAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}