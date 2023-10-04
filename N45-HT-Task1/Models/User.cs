using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N45_HT_Task1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public User(int id,string firstname)
        {
            Id = id;
            FirstName = firstname;
        }
    }
}
