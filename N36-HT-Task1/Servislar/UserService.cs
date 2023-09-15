using System.Collections.Generic;

namespace N36_HT_Task1.Servislar
{
    public class UserService
    {
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User(firstName: "John", lastName: "Smith", status: Status.Active, email: "johndoe@gmail.com"),
                new User(firstName: "bunyod", lastName: "bekjon", status: Status.Registered, email: "johnibek12@gmail.com"),
                new User(firstName: "Mahmud", lastName: "Javlonov", status: Status.Deleted, email: "gayrat@gmail.com"),
            };
            foreach (var user in users)
                yield return user;
         
        }
    }
}