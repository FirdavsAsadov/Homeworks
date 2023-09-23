using System;
using System.Threading.Tasks;

namespace N43_Ht_Task1.Interfeys
{
    public interface IEmployeeService
    {
        Task CreatePerformanceRecordAsync(Guid id);
    }
}