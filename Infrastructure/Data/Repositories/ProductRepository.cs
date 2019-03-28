using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(InventoryDBContext context) : base(context)
        {
            
        }

        public IEnumerable<Product> ProductListByCategory(int categoryId)
        {
            return null;

        }


    }


}
