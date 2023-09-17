using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace N38_HT_Task1
{
    public class UsersContainer : IEnumerable
    {
        List<User> _users = new List<User>();
        public UsersContainer()
        {
            
        }

        public UsersContainer(IEnumerable<User> users)
        {
           this._users.AddRange(users);
        }
        public User this [Guid id] => _users.FirstOrDefault(x => x.Id == id);
        public User this [string keyword] => _users.FirstOrDefault(x => x.FirstName == keyword.ToLower() || x.LastName == keyword.ToLower() || x.Email == keyword.ToLower());

        public User this[int index]
        {
            get
            {
                if (index > 0 && index < _users.Count)
                {
                    return _users[index];
                }

                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _users.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<User> Where(Func<User, bool> predicate)
        {
            return _users.Where(predicate);
        }
    }
}