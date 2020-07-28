using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DropDownExaple.Models
{
    public partial class CountryMaster
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="Country Name")]
        public string Name { get; set; }
        
        public string CountryCode { get; set; }
    }
}
