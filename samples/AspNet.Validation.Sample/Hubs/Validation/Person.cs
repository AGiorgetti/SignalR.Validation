using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet.Validation.Sample.Hubs.Validation
{
    public class Person
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Address { get; set; }
    }
}