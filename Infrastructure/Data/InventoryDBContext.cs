using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class InventoryDBContext : DbContext
    {


        public InventoryDBContext() : base("inventoryConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }


}
