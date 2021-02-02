using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC_2021.Models
{
    public class EmployeesMetadata
    {
        private pubsEntities db = new pubsEntities();

        [Display(Name = "Employee Id")]
        [Required(ErrorMessage = "This field is required!")]
        public string emp_id;

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 20 characters!")]
        public string fname;

        [Display(Name = "Minutes In Trail")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Input must be one character!")]
        public string minit;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 30 characters!")]
        public string lname;

        [Display(Name = "Job ID")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int job_id;

        [Display(Name = "Job level")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Wrong input format!")]
        public int job_lvl;

        [Display(Name = "Publication ID")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Publication ID must be 4 characters!")]
        public string pub_id;

        [Display(Name = "Hire date")]
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> hire_date;



    }
}