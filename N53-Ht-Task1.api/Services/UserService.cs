using N53_Ht_Task1.api.DataAccess;
using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;
using System.Linq.Expressions;

namespace N53_Ht_Task1.api.Services
{
    public class UserService : IUserService
    {
        private readonly IDataContext  _dataContext;

        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async ValueTask<User> CreateAsync(User user)
        {
            var entity = await _dataContext.Users.AddAsync(user);

            await _dataContext.SaveChangesAsync();

            return entity.Entity;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
             => _dataContext.Users.Where(predicate.Compile()).AsQueryable();
    }
}
