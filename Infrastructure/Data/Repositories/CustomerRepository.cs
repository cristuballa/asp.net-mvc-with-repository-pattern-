
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(InventoryDBContext context) : base(context)
        {

        }
        public IEnumerable<Customer> CustomerList(int categoryId)
        {
            return null;

        }
    }



}
