using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Market_Shop.Models
{
    public class categroy
    {
      
        public int id { get; set; }

        [Display(Name ="Categroy ")]
        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }
}