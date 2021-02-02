using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class AuthorsMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Author ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Author ID must be 11 characters!")]
        public string au_id;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 40 characters!")]
        public string au_lname;

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 20 characters!")]
        public string au_fname;

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "This field is required!")]
        [Phone(ErrorMessage = "Wrong phone")]
        public string phone;

        [Display(Name = "Address")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 40 characters!")]
        public string address;

        [Display(Name = "City")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 40 characters!")]
        public string city;

        [Display(Name = "State")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Address must be 2 characters long!")]
        public string state;

        [Display(Name = "Zip Code")]
        [Range(10400, 85999, ErrorMessage = "Wrong zip code format!")]
        public string zip;
    }
}