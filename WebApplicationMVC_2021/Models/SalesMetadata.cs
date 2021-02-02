using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class SalesMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Store ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Store ID must be 4 characters!")]
        public string stor_id;

        [Display(Name = "Order number")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Order number must be between 3 and 20 characters!")]
        public string ord_num;

        [Display(Name = "Order date")]
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ord_date;

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int qty;

        [Display(Name = "Payterms")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Payterms must be between 6 and 12 characters!")]
        public string payterms;

        [Display(Name = "Title ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Title ID must be 6 characters!")]
        public string title_id;

    }
}