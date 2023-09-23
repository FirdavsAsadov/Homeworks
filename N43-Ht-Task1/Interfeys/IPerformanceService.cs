using System;
using System.Threading.Tasks;

namespace N43_Ht_Task1.Interfeys
{
    public interface IPerformanceService
    {
        Task<bool> ReportPerformanceAsync(Guid id);
    }
}