
using ApplicationCore.Interfaces;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDBContext Context = new InventoryDBContext();
        public UnitOfWork()
        {
            Products = new ProductRepository(Context);
            Customers = new CustomerRepository(Context);
            Employees = new EmployeeRepository(Context);
        }

        public IProductRepository Products { get; set; }
        public ICustomerRepository Customers { get; set; }
        public IEmployeeRepository Employees { get; set; }

        public void Complete()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }

}
