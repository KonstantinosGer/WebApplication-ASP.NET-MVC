using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class TitleAuthorsMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Author ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Author ID must be 11 characters!")]
        public string au_id;

        [Display(Name = "Title ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Title ID must be 6 characters!")]
        public string title_id;

        [Display(Name = "Number of orders")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int au_ord;

        [Display(Name = "Royalty per author")]
        [Range(0, int.MaxValue, ErrorMessage = "Wrong input format!")]
        public int royaltyper;
    }
}