using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> SupplierListByCategory(int categoryId);
    }
}