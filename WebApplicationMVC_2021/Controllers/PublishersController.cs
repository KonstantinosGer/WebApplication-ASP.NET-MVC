﻿using System;
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
    public class PublishersController : Controller
    {
        private pubsEntities db = new pubsEntities();

        // GET: Publishers
        public ActionResult Index()
        {
            var publishers = db.publishers.Include(p => p.pub_info);
            return View(publishers.ToList());
        }

        // GET: Publishers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishers publishers = db.publishers.Find(id);
            if (publishers == null)
            {
                return HttpNotFound();
            }
            return View(publishers);
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            ViewBag.pub_id = new SelectList(db.pub_info, "pub_id", "pr_info");
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pub_id,pub_name,city,state,country")] publishers publishers)
        {
            if (ModelState.IsValid)
            {
                db.publishers.Add(publishers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pub_id = new SelectList(db.pub_info, "pub_id", "pr_info", publishers.pub_id);
            return View(publishers);
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishers publishers = db.publishers.Find(id);
            if (publishers == null)
            {
                return HttpNotFound();
            }
            ViewBag.pub_id = new SelectList(db.pub_info, "pub_id", "pr_info", publishers.pub_id);
            return View(publishers);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pub_id,pub_name,city,state,country")] publishers publishers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publishers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pub_id = new SelectList(db.pub_info, "pub_id", "pr_info", publishers.pub_id);
            return View(publishers);
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishers publishers = db.publishers.Find(id);
            if (publishers == null)
            {
                return HttpNotFound();
            }
            return View(publishers);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            publishers publishers = db.publishers.Find(id);
            db.publishers.Remove(publishers);
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
