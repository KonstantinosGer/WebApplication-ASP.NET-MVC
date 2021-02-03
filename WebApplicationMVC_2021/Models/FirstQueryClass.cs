using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMVC_2021.Models
{
    public class FirstQueryClass
    {
        public sales saleslist
        {
            get; set;
        }
        public titleauthor titleauthorlist
        {
            get; set;
        }
        public authors authorslist
        {
            get; set;
        }
        public object Amount { get; internal set; }
    }
}