using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EbookRentalShop.Models;

namespace EbookRentalShop.Controllers
{
    public class EbooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ebooks
        public ActionResult Index()
        {
            return View(db.Ebooks.ToList());
        }


        // GET: Ebooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebooks ebooks = db.Ebooks.Find(id);
            if (ebooks == null)
            {
                return HttpNotFound();
            }
            return View(ebooks);
        }

        // GET: Ebooks/Create
        public ActionResult Create()
        {
            PopulateAuthorsDropDownList();
            PopulateCategoriesDropDownList();
            PopulatePublishersDropDownList();
            return View();
        }

        // POST: Ebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EbookID,Title,Description,AuthorID,CategoryID,ReleaseDate,PublisherID")] Ebooks ebooks)
        {
            
            if (ModelState.IsValid)
            {
                db.Ebooks.Add(ebooks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAuthorsDropDownList(ebooks.AuthorID);
            PopulateCategoriesDropDownList(ebooks.CategoryID);
            PopulatePublishersDropDownList(ebooks.PublisherID);
            return View(ebooks);
        }

        // GET: Ebooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebooks ebooks = db.Ebooks.Find(id);
            if (ebooks == null)
            {
                return HttpNotFound();
            }
            return View(ebooks);
        }

        // POST: Ebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EbookID,Title,Description,AuthorID,CategoryID,ReleaseDate,PublisherID")] Ebooks ebooks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ebooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ebooks);
        }

        // GET: Ebooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebooks ebooks = db.Ebooks.Find(id);
            if (ebooks == null)
            {
                return HttpNotFound();
            }
            return View(ebooks);
        }

        // POST: Ebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ebooks ebooks = db.Ebooks.Find(id);
            db.Ebooks.Remove(ebooks);
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

        private void PopulateAuthorsDropDownList(object selectAuthor = null)
        {
            var AuthorQuery = from d in db.Authors
                            orderby d.LastName
                            select d;
            ViewBag.AuthorID = new SelectList(AuthorQuery, "AuthorID", null, selectAuthor);
        }
        private void PopulatePublishersDropDownList(object selectPublisher = null)
        {
            var PublisherQuery = from d in db.Publishers
                              orderby d.Name
                              select d;
            ViewBag.PublisherID = new SelectList(PublisherQuery, "PublisherID", "Name", selectPublisher);
        }
        private void PopulateCategoriesDropDownList(object selectCategory = null)
        {
            var CategoryQuery = from d in db.Categories
                              orderby d.Name
                              select d;
            ViewBag.CategoryID = new SelectList(CategoryQuery, "CategoryID", "Name", selectCategory);
        }
    }
}
