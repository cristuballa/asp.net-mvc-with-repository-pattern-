using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Person
    {
        [Display(Name="First Name")]
        public string FirstName { get; set; } 
        [Display(Name="Last Name")]
        public string LastName { get; set; } 
        public string Name => FirstName + " " + LastName;

    }
}
