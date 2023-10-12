using N52_ht_Task_1.DataAccess;
using N52_ht_Task_1.Models;
using N52_ht_Task_1.Services.Interfeys;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N52_ht_Task_1.Services
{
    public class UserService : IUserService
    {
        private readonly IDataContext _appDataContext;
        private readonly AccountEventstore _eventStore;
        public UserService(IDataContext appDataContext, AccountEventstore eventStore)
        {
            _appDataContext = appDataContext;
            _eventStore = eventStore;

        }

        public async ValueTask<User> CreateAsync(User user)
        {

            Validate(user);

            var entity = await _appDataContext.Users.AddAsync(user);
            await _appDataContext.SaveChangesAsync();

            await _eventStore.CreateUserAddedEventAsync(user);

            return entity.Entity;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
     => _appDataContext.Users.Where(predicate.Compile()).AsQueryable();
        private void Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName)
                || string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new ArgumentException("Invalid full name");
            }

            if (!Regex.IsMatch(user.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                throw new ArgumentException("Invalid email");
        }
    }
}
