using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class DiscountsMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Discount Type")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Discount Type must be between 3 and 40 characters!")]
        public string discounttype;

        [Display(Name = "Low Quantity")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int lowqty;

        [Display(Name = "High Quantity")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int highqty;

        [Display(Name = "Discount")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(0, double.MaxValue, ErrorMessage = "Wrong input format!")]
        public double discount;

        [Display(Name = "Discount Id")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(0, int.MaxValue, ErrorMessage = "Wrong input format!")]
        public int discount_id;
    }
}