﻿using System;
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
            //int x = 0;
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


            /*ViewData["jointables"] = (from s in saleslist
                                      where s.ord_date >= startDate && s.ord_date <= endDate
                                      join ta in titleauthorlist on s.title_id equals ta.title_id into table1
                                      from ta in table1.DefaultIfEmpty()
                                      join a in authorslist on ta.au_id equals a.au_id into table2
                                      from a in table2.DefaultIfEmpty()
                                      group s by s.qty into odg
                                      //group s by new { s.qty, saleslist = s, titleauthorlist = ta , authorslist = a} into sumgroup
                                      //group s by new { s.qty, ta, a} into g
                                      select new FirstQueryClass
                                      { saleslist = s, titleauthorlist = ta,
                                          authorslist = a,
                                          
                                          //Header = odg.Key,
                                          //TotalQuantity = odg.Sum(m => m.qty)
                                          Header = odg.Key,
                                          TotalQuantity = odg.Sum(s => s.qty)
                                      }).Take(x);*/

            ViewData["jointables"] = (from a in authorslist
                                      join ta in titleauthorlist on a.au_id equals ta.au_id
                                      join s in saleslist on ta.title_id equals s.title_id
                                      where s.ord_date >= startDate && s.ord_date <= endDate
                                      //group s by new { /*ta.au_id, a.phone*/ s, ta, a } into g
                                      //group s by new { s, ta, a, s.title_id, a.au_id, a.au_lname, a.au_fname, a.phone } into g
                                      group s by new { a, /*s.title_id*/ } into g
                                      select new FirstQueryClass
                                      {
                                          //saleslist = g.Key.s,
                                          //titleauthorlist = g.Key.ta,
                                          authorslist = g.Key.a,
                                          Amount = g.Sum(s => s.qty)
                                      }).OrderByDescending(i => i.Amount).Take(x);

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