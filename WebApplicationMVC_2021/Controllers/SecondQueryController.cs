using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC_2021.Models;

namespace WebApplicationMVC_2021.Controllers
{
    public class SecondQueryController : Controller
    {
        // GET: SecondQuery
        public ActionResult Index()
        {
            pubsEntities db = new pubsEntities();
            List<sales> saleslist = db.sales.ToList();
            List<titles> titleslist = db.titles.ToList();
            List<stores> storeslist = db.stores.ToList();

            string prefix = "";
            string suffix = "";
            DateTime startDate = new DateTime(1992, 06, 15);
            DateTime endDate = DateTime.Now;
            if (Request.QueryString["storeNamePrefix"] != null && Request.QueryString["storeNamePrefix"] != "")
            {
                prefix = Request.QueryString["storeNamePrefix"];
            }

            if (Request.QueryString["storeNameSuffix"] != null && Request.QueryString["storeNameSuffix"] != "")
            {
                suffix = Request.QueryString["storeNameSuffix"];
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


            ViewData["jointables"] = (from st in storeslist
                                      join s in saleslist on st.stor_id equals s.stor_id
                                      join t in titleslist on s.title_id equals t.title_id
                                      where s.ord_date >= startDate && s.ord_date <= endDate && st.stor_name.StartsWith(prefix) && st.stor_name.EndsWith(suffix)
                                      group s by new { s, st, t} into g
                                      select new SecondQueryClass
                                      {
                                          saleslist = g.Key.s,
                                          storeslist = g.Key.st,
                                          titleslist = g.Key.t
                                      });


            return View(ViewData["jointables"]);
        }

        //
        // Functions for redirecting from one Controller to another (from View to View)
        //
        public ActionResult GoToAuthors()
        {
            return RedirectToAction("Index", "Authors");
        }
        public ActionResult GoToDiscounts()
        {
            return RedirectToAction("Index", "Discounts");
        }
        public ActionResult GoToEmployees()
        {
            return RedirectToAction("Index", "Employees");
        }
        public ActionResult GoToJobs()
        {
            return RedirectToAction("Index", "Jobs");
        }
        public ActionResult GoToPublishersInfo()
        {
            return RedirectToAction("Index", "Pub_info");
        }
        public ActionResult GoToPublishers()
        {
            return RedirectToAction("Index", "Publishers");
        }
        public ActionResult GoToRoyscheds()
        {
            return RedirectToAction("Index", "Royscheds");
        }
        public ActionResult GoToSales()
        {
            return RedirectToAction("Index", "Sales");
        }
        public ActionResult GoToStores()
        {
            return RedirectToAction("Index", "Stores");
        }
        public ActionResult GoToTitleAuthors()
        {
            return RedirectToAction("Index", "TitleAuthors");
        }
        public ActionResult GoToTitles()
        {
            return RedirectToAction("Index", "Titles");
        }
        public ActionResult GoToFirstQuery()
        {
            return RedirectToAction("Index", "FirstQuery");
        }
        public ActionResult GoToSecondQuery()
        {
            return RedirectToAction("Index", "SecondQuery");
        }
    }
}