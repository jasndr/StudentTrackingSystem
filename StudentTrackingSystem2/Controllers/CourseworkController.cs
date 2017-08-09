using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentTrackingSystem2.Models;

namespace StudentTrackingSystem2.Controllers
{
    public class CourseworkController : Controller
    {
        private GraduateStudentRecord db = new GraduateStudentRecord();

        // GET: Coursework
        public ActionResult Index()
        {
            var graduate_Coursework = db.Graduate_Coursework.Include(g => g.Graduate_CommonFields).Include(g => g.Graduate_Course).Include(g => g.Graduate_Student);
            return View(graduate_Coursework.ToList());
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
            ViewBag.SemesterID = new SelectList(db.Graduate_CommonFields, "Id", "Name");
            ViewBag.CourseID = new SelectList(db.Graduate_Course, "Id", "Name");
            ViewBag.StudentID = new SelectList(db.Graduate_Student, "Id", "FirstName");
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

            ViewBag.SemesterID = new SelectList(db.Graduate_CommonFields, "Id", "Name", graduate_Coursework.SemesterID);
            ViewBag.CourseID = new SelectList(db.Graduate_Course, "Id", "Name", graduate_Coursework.CourseID);
            ViewBag.StudentID = new SelectList(db.Graduate_Student, "Id", "FirstName", graduate_Coursework.StudentID);
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
            ViewBag.SemesterID = new SelectList(db.Graduate_CommonFields, "Id", "Name", graduate_Coursework.SemesterID);
            ViewBag.CourseID = new SelectList(db.Graduate_Course, "Id", "Name", graduate_Coursework.CourseID);
            ViewBag.StudentID = new SelectList(db.Graduate_Student, "Id", "FirstName", graduate_Coursework.StudentID);
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
            ViewBag.SemesterID = new SelectList(db.Graduate_CommonFields, "Id", "Name", graduate_Coursework.SemesterID);
            ViewBag.CourseID = new SelectList(db.Graduate_Course, "Id", "Name", graduate_Coursework.CourseID);
            ViewBag.StudentID = new SelectList(db.Graduate_Student, "Id", "FirstName", graduate_Coursework.StudentID);
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
