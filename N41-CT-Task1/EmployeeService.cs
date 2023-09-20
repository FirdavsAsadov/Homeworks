using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace N41_CT_Task1
{
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public Employee? GetByEmail(string email)
        {
            Thread.Sleep(5000);
            return _employees.FirstOrDefault(e => e.EmailAddress == email);
        }
    }
}