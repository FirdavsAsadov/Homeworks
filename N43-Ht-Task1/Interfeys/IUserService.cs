using System;
using System.Collections.Generic;

namespace N43_Ht_Task1.Interfeys
{
    public interface IUserService
    {
        User Create(User user);
        bool Delete(Guid id);
        User Get(Guid id);
        User Update(User user);
        List<User> GetAll();
    }
}