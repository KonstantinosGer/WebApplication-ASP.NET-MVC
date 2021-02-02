using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class PublishersMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Publication ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Publication ID must be 4 characters!")]
        public string pub_id;

        [Display(Name = "Publication Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Publication name must be between 3 and 40 characters!")]
        public string pub_name;

        [Display(Name = "City")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "City must be between 3 and 20 characters!")]
        public string city;

        [Display(Name = "State")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be 2 characters!")]
        public string state;

        [Display(Name = "Country")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Country must be between 3 and 30 characters!")]
        public string country;
    }
}