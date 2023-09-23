using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using N43_Ht_Task1.Interfeys;

namespace N43_Ht_Task1.Service
{
    public class PerformanceService : IPerformanceService
    {
        private readonly IUserService _userService;
        private Mutex _mutex = new Mutex(false,"mutexx");

        public PerformanceService(IUserService userService)
        {
            _userService = userService;
        }
        public Task<bool> ReportPerformanceAsync(Guid id)
        {
            return Task.Run(() =>
            {
                _mutex.WaitOne();
                var founndetUser = _userService.Get(id);
                if (founndetUser != null)
                {
                    var Fullname = $"{founndetUser.FirstName} {founndetUser.LastName}.txt";
                    File.WriteAllText(Fullname, "All good :)");
                    return true;
                }

                return false;
                _mutex.ReleaseMutex();
            });
        }
    }
}