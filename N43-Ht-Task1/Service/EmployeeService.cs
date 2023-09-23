using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using N43_Ht_Task1.Interfeys;

namespace N43_Ht_Task1.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserService _userService;
        private Mutex _mutex = new Mutex(false,"_mutexx");

        public EmployeeService(IUserService userService)
        {
            _userService = userService;
        }
        public Task CreatePerformanceRecordAsync(Guid id)
        {
            return Task.Run(() =>
            {
                _mutex.WaitOne();
                var foundedUser = _userService.Get(id);
                if (foundedUser != null)
                {
                    var fulname = $"{foundedUser.FirstName} {foundedUser.LastName}.txt";
                    File.Create(fulname).Close();
                }
                
                _mutex.ReleaseMutex();
            });
        }
    }
}