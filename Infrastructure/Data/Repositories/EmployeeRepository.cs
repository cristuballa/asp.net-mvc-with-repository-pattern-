
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(InventoryDBContext context) : base(context)
        {

        }
        public IEnumerable<Employee> EmployeeList(int id)
        {
            return null;

        }
    }



}
