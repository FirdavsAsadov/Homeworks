using System;

namespace N38_HT_Task1
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public User(string firstname, string lastname, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
    }
    
}