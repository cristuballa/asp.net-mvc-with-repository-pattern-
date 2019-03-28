using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {

        public SupplierRepository(InventoryDBContext context) : base(context)
        {

        }

        public IEnumerable<Supplier> SupplierListByCategory(int categoryId)
        {
            return null;

        }


    }


}
