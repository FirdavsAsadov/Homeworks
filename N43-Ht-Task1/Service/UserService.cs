using System;
using System.Collections.Generic;
using System.Linq;
using N43_Ht_Task1.Interfeys;

namespace N43_Ht_Task1.Service
{
    public class UserService : IUserService
    {
        List<User> users = new List<User>();
        public User Create(User user)
        {
            if (user != null)
            {
                users.Add(user);
                return user;
            }
            return null;
        }

        public bool Delete(Guid id)
        {
            var foundUser = users.FirstOrDefault(x => x.Id == id);
            if (foundUser!= null)
            {
                users.Remove(foundUser);
                return true;
            }
            return false;
        }

        public User Get(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public User Update(User user)
        {
            if (user!= null)
            {
                var foundUser = users.FirstOrDefault(x => x.Id == user.Id);
                if (foundUser!= null)
                {
                    foundUser.FirstName = user.FirstName;
                    foundUser.LastName = user.LastName;
                    foundUser.IsActive = user.IsActive;
                    return foundUser;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return users;
        }
    }
}