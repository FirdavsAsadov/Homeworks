using System.Collections.Generic;
using System.Linq;

namespace N35_HT_Task3
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>();
        private int nextId = 1;
        public User CreateUser(User user)
        {
            user.Id = nextId++;
            _users.Add(user);
            return user;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void UpdateUser(int id, User user)
        {
            var userToUpdate = _users.FirstOrDefault(u => u.Id == id);
            if (userToUpdate!= null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
            }
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _users.FirstOrDefault(u => u.Id == id);
            if (userToDelete!= null)
            {
                _users.Remove(userToDelete);
            }
        }
    }
}