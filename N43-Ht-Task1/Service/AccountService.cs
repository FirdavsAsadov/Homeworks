using System;
using System.Threading.Tasks;
using N43_Ht_Task1.Interfeys;

namespace N43_Ht_Task1.Service
{
    public class AccountService : IAccountService
    {
        private readonly IPerformanceService _performanceService;
        private readonly IEmployeeService _employeeService;
        public AccountService(IPerformanceService performanceService,IEmployeeService employeeService)
        {
            _performanceService = performanceService;
            _employeeService = employeeService;
        }
        public Task CreateReportAsync(Guid id)
        {
            var result = _employeeService.CreatePerformanceRecordAsync(id)
                .ContinueWith(x => _performanceService.ReportPerformanceAsync(id));
            return result;
        }
    }
}