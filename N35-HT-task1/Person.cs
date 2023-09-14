using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N35_HT_task1
{
    public record Person(int Id, string Name, string LastName, string Fullname,string Email, string Password);

    public record Employe(int Id, string Username, string Rating,string Email, string Password);

    public record Manager(int Id, string Username, string Rating, string FirstName, string LastName, string Email,string Password)
        : Employe(Id,Username,Rating,Email,Password);
}
