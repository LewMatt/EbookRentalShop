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
    public class BorrowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        // GET: Borrows
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var listOfUsers = (from u in db.Users
                               let query = (from ur in db.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in db.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                         .ToList();


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var userRole = listOfUsers.Where(p => p.User.Id == User.Identity.GetUserId());
            var res = db.Borrows.ToList();
            if((Request.IsAuthenticated) && !(userRole.First().Roles.Contains("SuperAdmin")))
            {
                var books = res.Where(p => p.UserID == User.Identity.GetUserId());
                return View(books);
            }
            return View(res);
        }


        // GET: Borrows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrows borrows = db.Borrows.Find(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            return View(borrows);
        }

        // GET: Borrows/Create
        public ActionResult Create(int EbookID, string UserID)
        {
            var borrows = new Borrows();
            borrows.EbookID = EbookID;
            borrows.UserID = UserID;
            borrows.BorrowDate = DateTime.Now;
            borrows.ReturnDate = DateTime.Now.AddDays(7);
            db.Borrows.Add(borrows);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BorrowID,UserID,EbookID")] Borrows borrows)
        {
            borrows.BorrowDate = DateTime.Now;
            borrows.ReturnDate = DateTime.Now.AddDays(7);

            if (ModelState.IsValid)
            {
                db.Borrows.Add(borrows);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(borrows);
        }

        // GET: Borrows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrows borrows = db.Borrows.Find(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            return View(borrows);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BorrowID,UserID,EbookID,BorrowDate,ReturnDate")] Borrows borrows)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrows).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrows);
        }

        // GET: Borrows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrows borrows = db.Borrows.Find(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            return View(borrows);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Borrows borrows = db.Borrows.Find(id);
            db.Borrows.Remove(borrows);
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

        public ActionResult BorrowAdd(int EbookID, string UserID)
        {
            
            var isExist = db.Borrows.Where(p => p.UserID == UserID && p.EbookID == EbookID);
            
            if(isExist.Count()==0)
            {
                var borrows = new Borrows();
                borrows.EbookID = EbookID;
                borrows.UserID = UserID;
                borrows.BorrowDate = DateTime.Now;
                borrows.ReturnDate = DateTime.Now.AddDays(7);
                db.Borrows.Add(borrows);
                db.SaveChanges();

                return RedirectToAction("Success","Borrows");
            }
            else
            {
                return RedirectToAction("Index","Ebooks");
            }
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
