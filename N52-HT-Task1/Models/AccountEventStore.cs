using System;
using System.Threading.Tasks;

namespace N52_HT_Task1.Models
{
    public class AccountEventStore
    {
        public event Func<User, ValueTask> OnUserCreated; 

        public async ValueTask CreateUserAddedEventAsync(User user)
        {
            if (OnUserCreated != null)
                await OnUserCreated(user);
        }
    }
}