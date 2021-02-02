using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class StoresMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Store ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Store ID must be 4 characters!")]
        public string stor_id;

        [Display(Name = "Store name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Store name must be between 3 and 40 characters!")]
        public string stor_name;

        [Display(Name = "Store address")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Store address must be between 3 and 40 characters!")]
        public string stor_address;

        [Display(Name = "City")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "City must be between 3 and 20 characters!")]
        public string city;

        [Display(Name = "State")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be 2 characters!")]
        public string state;

        [Display(Name = "Zip Code")]
        [Range(10400, 85999, ErrorMessage = "Wrong zip code format!")]
        public string zip;

    }
}