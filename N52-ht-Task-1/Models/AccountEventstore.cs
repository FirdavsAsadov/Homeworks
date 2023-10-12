namespace N52_ht_Task_1.Models
{
    public class AccountEventstore
    {
        public event Func<User, ValueTask>? OnUserCreated;

        public async ValueTask CreateUserAddedEventAsync(User user)
        {
            if (OnUserCreated != null)
                await OnUserCreated(user);
        }
    }
}
