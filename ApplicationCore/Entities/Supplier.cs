using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Supplier:BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string EmailAdd { get; set; }
        public string ContactInfo { get; set; }
        public Address Address { get; set; }

    }
}
