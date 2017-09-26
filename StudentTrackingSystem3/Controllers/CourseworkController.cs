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
    public class CourseworkController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Coursework
        public ActionResult Index(int? id)
        {
            var coursework = db.Coursework.Include(g => g.Course).Include(g => g.Semesters).Include(g => g.Student).Where(g=>g.StudentID == id);

            ViewBag.CurrentStudent_FirstName = db.Students.Find(id).FirstName;
            ViewBag.CurrentStudent_LastName = db.Students.Find(id).LastName;
            ViewBag.CurrentStudent_Id = (int)id;
            return View(coursework.ToList());
        }

        // GET: Coursework/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Coursework g_Coursework = db.Coursework.Find(id);
            if (g_Coursework == null)
            {
                return HttpNotFound();
            }
            return View(g_Coursework);
        }

        // GET: Coursework/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum");
            ViewBag.SemestersID = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");
            ViewBag.GradeID = new SelectList(db.CommonFields.Where(o => o.Category == "Grade"), "Id", "Name");
            return View();
        }

        // POST: Coursework/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,SemestersID,Year,CourseID,Grade")] G_Coursework g_Coursework)
        {
            if (ModelState.IsValid)
            {
                db.Coursework.Add(g_Coursework);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum", g_Coursework.CourseID);
            ViewBag.SemestersID = new SelectList(db.CommonFields, "ID", "Name", g_Coursework.SemestersID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_Coursework.StudentID);
            return View(g_Coursework);
        }

        // GET: Coursework/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Coursework g_Coursework = db.Coursework.Find(id);
            if (g_Coursework == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum", g_Coursework.CourseID);
            ViewBag.SemestersID = new SelectList(db.CommonFields, "ID", "Name", g_Coursework.SemestersID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_Coursework.StudentID);
            return View(g_Coursework);
        }

        // POST: Coursework/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,SemestersID,Year,CourseID,Grade")] G_Coursework g_Coursework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Coursework).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum", g_Coursework.CourseID);
            ViewBag.SemestersID = new SelectList(db.CommonFields, "ID", "Name", g_Coursework.SemestersID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_Coursework.StudentID);
            return View(g_Coursework);
        }

        // GET: Coursework/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Coursework g_Coursework = db.Coursework.Find(id);
            if (g_Coursework == null)
            {
                return HttpNotFound();
            }
            return View(g_Coursework);
        }

        // POST: Coursework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Coursework g_Coursework = db.Coursework.Find(id);
            db.Coursework.Remove(g_Coursework);
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
