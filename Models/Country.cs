using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market_Shop.Models
{
    public class Country
    {
        
        public int ID { get; set; }

        [Display(Name ="Country name:")]
        [Required(ErrorMessage ="Should Enter name")]
        [StringLength(50,ErrorMessage ="Should be 50 letter!")]
        public string Country_Name { get; set; }

    }
}