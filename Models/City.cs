using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;



namespace Market_Shop.Models
{
    public class City
    {
        public int ID { get; set; }
        [Display(Name = "City name:")]
        [Required(ErrorMessage = "Should Enter name")]
        [StringLength(50, ErrorMessage = "Should be 50 letter!")]
        public string City_Name { get; set; }
        public Country Country { get; set; }

        [ForeignKey("Country")]
        public int Country_ID { get; set; }
    }
}