using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class Pub_infoMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Publication ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Publication ID must be 4 characters!")]
        public string pub_id;

        [Display(Name = "Logo")]
        public byte logo;

        [Display(Name = "Info")]
        public string pr_info;
    }
}