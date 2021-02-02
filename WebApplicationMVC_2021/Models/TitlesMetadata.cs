using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class TitlesMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Title ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Title ID must be 6 characters!")]
        public string title_id;

        [Display(Name = "Title")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 80 characters!")]
        public string title;

        [Display(Name = "Type")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Type must be between 3 and 12 characters!")]
        public string type;

        [Display(Name = "Publication ID")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Publication ID must be 4 characters!")]
        public string pub_id;

        [Display(Name = "Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Wrong input format!")]
        public double price;

        [Display(Name = "Advance")]
        [Range(0, double.MaxValue, ErrorMessage = "Wrong input format!")]
        public double advance;

        [Display(Name = "Royalty")]
        [Range(0, int.MaxValue, ErrorMessage = "Wrong input format!")]
        public int royalty;

        [Display(Name = "Year-to-date sales ")]
        [Range(0, int.MaxValue, ErrorMessage = "Wrong input format!")]
        public int ytd_sales;

        [Display(Name = "Notes")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Notes must be between 3 and 200 characters!")]
        public string notes;

        [Display(Name = "Publication date")]
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> pubdate;

    }
}