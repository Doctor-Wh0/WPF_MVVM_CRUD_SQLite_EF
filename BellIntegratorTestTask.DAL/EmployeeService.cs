using BellIntegratorTestTask.Core.Models;
using BellIntegratorTestTask.DAL.Interfaces;

namespace BellIntegratorTestTask.DAL
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService(IRepository<Employee> repository)
            : base(repository)
        {

        }
    }
}
