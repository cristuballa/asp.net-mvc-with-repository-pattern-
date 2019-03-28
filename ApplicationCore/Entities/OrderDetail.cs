using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class OrderDetail:BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

    }
}
