using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplicationMVC_2021.Models
{
    public class RoyschedsMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Title ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Title ID must be 6 characters!")]
        public string title_id;

        [Display(Name = "Low range")]
        [Range(0, int.MaxValue, ErrorMessage = "Wrong input format!")]
        public int lorange;

        [Display(Name = "High range")]
        [Range(0, int.MaxValue, ErrorMessage = "Wrong input format!")]
        public int hirange;

        [Display(Name = "Royalty")]
        [Range(0, int.MaxValue, ErrorMessage = "Wrong input format!")]
        public int royalty;
    }
}