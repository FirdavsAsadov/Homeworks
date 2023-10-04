using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N44_HT_Task2
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public User(string? name, int age, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Email}";
        }
    }
}
