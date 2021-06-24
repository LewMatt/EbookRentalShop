using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EbookRentalShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EbookRentalShop.Controllers
{
    public class SuggestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        // GET: Suggestions
        public ActionResult Index()
        {
            return View(db.Suggestions.ToList());
        }

        // GET: Suggestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestions suggestions = db.Suggestions.Find(id);
            if (suggestions == null)
            {
                return HttpNotFound();
            }
            return View(suggestions);
        }
        [Authorize]
        // GET: Suggestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suggestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuggestionID,Title,Author")] Suggestions suggestions)
        {
            suggestions.UserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Suggestions.Add(suggestions);
                db.SaveChanges();
                return RedirectToAction("Success","Suggestions");
            }

            return View(suggestions);
        }

        // GET: Suggestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestions suggestions = db.Suggestions.Find(id);
            if (suggestions == null)
            {
                return HttpNotFound();
            }
            return View(suggestions);
        }

        // POST: Suggestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuggestionID,UserID,Title,Author")] Suggestions suggestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestions);
        }

        // GET: Suggestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestions suggestions = db.Suggestions.Find(id);
            if (suggestions == null)
            {
                return HttpNotFound();
            }
            return View(suggestions);
        }

        // POST: Suggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suggestions suggestions = db.Suggestions.Find(id);
            db.Suggestions.Remove(suggestions);
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

        public ActionResult Success()
        {
            return View();
        }
    }
}
