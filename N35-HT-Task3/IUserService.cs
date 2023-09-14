using System.Collections.Generic;

namespace N35_HT_Task3
{
    public interface IUserService
    {
        User CreateUser(User user);
        User GetUserById(int id);
        IEnumerable<User> GetUsers();
        void UpdateUser(int id,User user);
        void DeleteUser(int id);
    }
}