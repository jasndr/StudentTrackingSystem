using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentTrackingSystem.Models;

namespace StudentTrackingSystem.Controllers
{
    public class CourseworkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coursework
        public ActionResult Index()
        {
            return View(db.Graduate_Coursework.ToList());
        }

        // GET: Coursework/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_Coursework graduate_Coursework = db.Graduate_Coursework.Find(id);
            if (graduate_Coursework == null)
            {
                return HttpNotFound();
            }
            return View(graduate_Coursework);
        }

        // GET: Coursework/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coursework/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentID,SemesterID,Year,CourseID")] Graduate_Coursework graduate_Coursework)
        {
            if (ModelState.IsValid)
            {
                db.Graduate_Coursework.Add(graduate_Coursework);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graduate_Coursework);
        }

        // GET: Coursework/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_Coursework graduate_Coursework = db.Graduate_Coursework.Find(id);
            if (graduate_Coursework == null)
            {
                return HttpNotFound();
            }
            return View(graduate_Coursework);
        }

        // POST: Coursework/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentID,SemesterID,Year,CourseID")] Graduate_Coursework graduate_Coursework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduate_Coursework).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graduate_Coursework);
        }

        // GET: Coursework/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_Coursework graduate_Coursework = db.Graduate_Coursework.Find(id);
            if (graduate_Coursework == null)
            {
                return HttpNotFound();
            }
            return View(graduate_Coursework);
        }

        // POST: Coursework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graduate_Coursework graduate_Coursework = db.Graduate_Coursework.Find(id);
            db.Graduate_Coursework.Remove(graduate_Coursework);
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
    }
}
