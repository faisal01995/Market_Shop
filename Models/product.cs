using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Market_Shop.Models
{
    public class product
    {
        public int id { get; set; }

        [Display(Name ="Name of product")]
        [Required]
        [StringLength(50)]

        public string name { get; set; }
        [Required]
        public int quntity { get; set; }
        [Required]
        public float price { get; set; }
       
        public string img { get; set; }
        public categroy categroy { get; set; }
        [ForeignKey("categroy")]
        public int categroyId { get; set; }
    }
}