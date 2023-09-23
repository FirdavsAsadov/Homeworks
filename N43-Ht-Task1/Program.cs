using N43_Ht_Task1.Interfeys;
using N43_Ht_Task1.Service;
using System.Threading.Tasks;

namespace N43_Ht_Task1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var user1 = new User("G'ishtmat", "Toshmatov", true);

            var userService = new UserService();
            userService.Create(user1);
            var employee = new EmployeeService(userService);
            var performane = new PerformanceService(userService);
            var accountService = new AccountService(performane, employee);
            await accountService.CreateReportAsync(user1.Id);
        }
    }
}