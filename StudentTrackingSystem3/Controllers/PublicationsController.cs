using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentTrackingSystem3.DAL;
using StudentTrackingSystem3.Models;

namespace StudentTrackingSystem3.Controllers
{
    public class PublicationsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Publications
        public ActionResult Index()
        {
            var publications = db.Publications.Include(g => g.PubMonth).Include(g => g.Student);
            return View(publications.ToList());
        }

        // GET: Publications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publications publications = db.Publications.Find(id);
            if (publications == null)
            {
                return HttpNotFound();
            }
            return View(publications);
        }

        // GET: Publications/Create
        public ActionResult Create(int? id)
        {
            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name");
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,PublicationInformation,PubMonthId,PubYear")] Publications publications)
        {
            if (ModelState.IsValid)
            {
                db.Publications.Add(publications);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = publications.StudentID });
            }

            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", publications.PubMonthId);
            ViewBag.StudentID = publications.StudentID;
            return View(publications);
        }

        // GET: Publications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publications publications = db.Publications.Find(id);
            Student student = publications.Student;
            if (publications == null)
            {
                return HttpNotFound();
            }
            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", publications.PubMonthId);
            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            return View(publications);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,PublicationInformation,PubMonthId,PubYear")] Publications publications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = publications.StudentID});
            }
            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", publications.PubMonthId);
            ViewBag.StudentID = publications.StudentID;
            return View(publications);
        }

        // GET: Publications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publications publications = db.Publications.Find(id);
            if (publications == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publications publications = db.Publications.Find(id);
            db.Publications.Remove(publications);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This publication record has been successfully deleted.')</script>";
            return RedirectToAction("Index", "PostGraduation", new { id = publications.StudentID });
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
