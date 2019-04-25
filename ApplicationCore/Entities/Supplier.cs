using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{


    public class Supplier : BaseEntity
    {
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        [Display(Name ="Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name ="Email Address")]
        public string EmailAdd { get; set; }
        [Display(Name ="Contact Info")]
        public string ContactInfo { get; set; }
        public Address Address { get; set; }

    }
}
