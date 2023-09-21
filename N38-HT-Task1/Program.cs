using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace N38_HT_Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var user1 = new User("John", "Doe", "john@example.com");
            var user2 = new User("Jane", "Smith", "jane@example.com");
            var user3 = new User("Bekjon", "Gohnson", "alice@example.com");

            // Create UsersContainer and add users
            var usersContainer = new UsersContainer(new List<User> { user1, user2, user3 });
            Console.WriteLine("Brinta harif kiriting: ");
            var keyword = Console.ReadLine();

            // Query using LINQ methods
            var queryResult = usersContainer.Where(u => u.FirstName.StartsWith(keyword, StringComparison.OrdinalIgnoreCase) || u.LastName.StartsWith(keyword, StringComparison.OrdinalIgnoreCase) || u.Email.StartsWith(keyword, StringComparison.OrdinalIgnoreCase));
            foreach (var user in queryResult)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }
    }
}