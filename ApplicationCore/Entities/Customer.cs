using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Customer : BaseEntity
    {

        [Display(Name="Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Email Add")]
        public string EmailAdd { get; set; }
        [Display(Name = "Contact Info")]
        public string ContactInfo { get; set; }
        public Address Address  { get; set; }
        public Address BillingAddress { get; set; }

    }
}
