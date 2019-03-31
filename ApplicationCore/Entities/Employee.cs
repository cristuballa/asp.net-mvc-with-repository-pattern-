using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Employee: BaseEntity
    {
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Contact No")]
        public string ContactNo { get; set; }
        public Address Address { get; set; }
  
    }
}
