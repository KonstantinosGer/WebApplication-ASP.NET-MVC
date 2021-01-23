using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC_2021.Models;

namespace WebApplicationMVC_2021.Controllers
{
    public class FirstQueryController : Controller
    {
        // GET: FirstQuery
        public ActionResult Index()
        {
            pubsEntities db = new pubsEntities();
            List<sales> saleslist = db.sales.ToList();
            List<titleauthor> titleauthorlist = db.titleauthor.ToList();
            List<authors> authorslist = db.authors.ToList();

            int x = 100;
            DateTime startDate = new DateTime(1992, 06, 15);
            DateTime endDate = DateTime.Now;
            if (Request.QueryString["numberX"] != null && Request.QueryString["numberX"] != "")
            {
                int.TryParse(Request.QueryString["numberX"], out int numberx);
                x = numberx;
            }

            if (Request.QueryString["dateFrom"] != null && Request.QueryString["dateFrom"] != "")
            {
                DateTime.TryParse(Request.QueryString["dateFrom"], out DateTime datefrom);
                startDate = datefrom;
            }

            if (Request.QueryString["dateTo"] != null && Request.QueryString["dateTo"] != "")
            {
                DateTime.TryParse(Request.QueryString["dateTo"], out DateTime dateto);
                endDate = dateto;
            }


            ViewData["jointables"] = (from s in saleslist                                      
                                      where s.ord_date >= startDate && s.ord_date <= endDate
                                      join ta in titleauthorlist on s.title_id equals ta.title_id into table1
                                      from ta in table1.DefaultIfEmpty()
                                      join a in authorslist on ta.au_id equals a.au_id into table2
                                      from a in table2.DefaultIfEmpty()
                                      group s by s.qty into odg
                                      //group s by new { s.qty, saleslist = s, titleauthorlist = ta , authorslist = a} into sumgroup
                                      select new FirstQueryClass
                                      { /*saleslist = s, titleauthorlist = ta,
                                          authorslist = a,*/
                                          Header = odg.Key,
                                          TotalQuantity = odg.Sum(m => m.qty)
                                      }).Take(x);
          
            return View(ViewData["jointables"]);
        }
    }
}