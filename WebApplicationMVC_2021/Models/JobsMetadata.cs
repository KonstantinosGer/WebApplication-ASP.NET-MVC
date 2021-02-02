using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class JobsMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Job ID")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int job_id;

        [Display(Name = "Job Position")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Job Position must be between 3 and 50 characters!")]
        public string job_desc;

        [Display(Name = "Minimum level")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int min_lvl;

        [Display(Name = "Maximum level")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int max_lvl;
    }
}