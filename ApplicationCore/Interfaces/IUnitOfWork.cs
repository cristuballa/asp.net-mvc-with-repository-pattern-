



namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; set; }
        ICustomerRepository Customers { get; set; }
        IEmployeeRepository Employees { get; set; }
        ISupplierRepository Suppliers { get; set; }
        void Complete();
        void Dispose();
    }
}