using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC_2021.Models;

namespace WebApplicationMVC_2021.Controllers
{
    public class SalesController : Controller
    {
        private pubsEntities db = new pubsEntities();
 
        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.sales.Include(s => s.stores).Include(s => s.titles);

            IQueryable<sales> list = db.sales;
            IQueryable<titleauthor> listTitleAuthors = db.titleauthor;
            IQueryable<authors> listAuthors = db.authors;

            if (Request.QueryString["numberX"] != null && Request.QueryString["numberX"] != "")
            {
                int.TryParse(Request.QueryString["numberX"], out int numberx);
                //var sortedList = list.OrderByDescending(m => m.qty).ToList();
            
                //List<sales> subList = sortedList.GetRange(0, numberx);


                //foreach (var element in subList)
                //{
                //    list.Append(element);
                //}
                list = list.Where(m => m.qty > numberx);

            }

            if (Request.QueryString["dateFrom"] != null && Request.QueryString["dateFrom"] != "")
            {
                DateTime.TryParse(Request.QueryString["dateFrom"], out DateTime datefrom);
                list = list.Where(m => m.ord_date >= datefrom);
            }

            if (Request.QueryString["dateTo"] != null && Request.QueryString["dateTo"] != "")
            {
                DateTime.TryParse(Request.QueryString["dateTo"], out DateTime dateto);
                list = list.Where(m => m.ord_date <= dateto);
            }

            /*
            var innerJoin = list.Join(// outer sequence 
                      listTitleAuthors,  // inner sequence 
                      sales => sales.title_id,    // outerKeySelector
                      titleauthor => titleauthor.title_id,  // innerKeySelector
                      (sales, titleauthor) => new  // result selector
                      {
                          //salesTitleId = sales.title_id,
                          //titleAuthorId = titleauthor.title_id
                          salesOrderDate = sales.ord_date,
                          salesQty = sales.qty,
                          salesPayterms = sales.payterms
                          
                      });

            foreach (var obj in innerJoin)
            {
                Console.WriteLine("{0} - {1} - {2}", obj.salesOrderDate, obj.salesQty, obj.salesPayterms);
                //list.Append( obj.salesOrderDate)
            }
            */


            return View(list.ToList());  
        }

        // GET: Sales/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales sales = db.sales.SingleOrDefault(m => m.stor_id + m.ord_num + m.title_id == id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }


        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.stor_id = new SelectList(db.stores, "stor_id", "stor_name");
            ViewBag.title_id = new SelectList(db.titles, "title_id", "title");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stor_id,ord_num,ord_date,qty,payterms,title_id")] sales sales)
        {
            if (ModelState.IsValid)
            {
                db.sales.Add(sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.stor_id = new SelectList(db.stores, "stor_id", "stor_name", sales.stor_id);
            ViewBag.title_id = new SelectList(db.titles, "title_id", "title", sales.title_id);
            return View(sales);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales sales = db.sales.SingleOrDefault(m => m.stor_id + m.ord_num + m.title_id == id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            ViewBag.stor_id = new SelectList(db.stores, "stor_id", "stor_name", sales.stor_id);
            ViewBag.title_id = new SelectList(db.titles, "title_id", "title", sales.title_id);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stor_id,ord_num,ord_date,qty,payterms,title_id")] sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.stor_id = new SelectList(db.stores, "stor_id", "stor_name", sales.stor_id);
            ViewBag.title_id = new SelectList(db.titles, "title_id", "title", sales.title_id);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales sales = db.sales.SingleOrDefault(m => m.stor_id + m.ord_num + m.title_id == id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sales sales = db.sales.SingleOrDefault(m => m.stor_id + m.ord_num + m.title_id == id);
            db.sales.Remove(sales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
