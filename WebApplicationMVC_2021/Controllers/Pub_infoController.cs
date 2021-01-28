using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC_2021.Models;

namespace WebApplicationMVC_2021.Controllers
{
    public class Pub_infoController : Controller
    {
        private pubsEntities db = new pubsEntities();

        // GET: Pub_info
        public ActionResult Index()
        {
            var pub_info = db.pub_info.Include(p => p.publishers);
            return View(pub_info.ToList());
        }

        // GET: Pub_info/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pub_info pub_info = db.pub_info.Find(id);
            if (pub_info == null)
            {
                return HttpNotFound();
            }
            return View(pub_info);
        }

        // GET: Pub_info/Create
        public ActionResult Create()
        {
            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name");
            return View();
        }

        // POST: Pub_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pub_id,logo,pr_info")] pub_info pub_info)
        {
            if (ModelState.IsValid)
            {
                db.pub_info.Add(pub_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name", pub_info.pub_id);
            return View(pub_info);
        }

        // GET: Pub_info/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pub_info pub_info = db.pub_info.Find(id);
            if (pub_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name", pub_info.pub_id);
            return View(pub_info);
        }

        // POST: Pub_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pub_id,logo,pr_info")] pub_info pub_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pub_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name", pub_info.pub_id);
            return View(pub_info);
        }

        // GET: Pub_info/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pub_info pub_info = db.pub_info.Find(id);
            if (pub_info == null)
            {
                return HttpNotFound();
            }
            return View(pub_info);
        }

        // POST: Pub_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pub_info pub_info = db.pub_info.Find(id);
            db.pub_info.Remove(pub_info);
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
