using System;

namespace ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public DateTime DateSold { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public Customer Customer { get; set; }
        public Employee SalesRep { get; set; }
        public string Reference { get; set; }

    }
}
