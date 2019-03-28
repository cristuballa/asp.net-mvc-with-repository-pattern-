using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        IEnumerable<Employee> EmployeeList(int id);
    }
}