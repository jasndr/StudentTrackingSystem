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
    public class PostGraduationController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: PostGraduation
        public ActionResult Index(int? id)
        {
            G_PostGraduation g_PostGraduation = db.Students.Find(id).PostGraduation.FirstOrDefault();
            if (g_PostGraduation == null)
            {
                return RedirectToAction("Create", new { id = id });
            }
            else
            {
                return RedirectToAction("Edit", new { id = id });
            }

            //var g_PostGraduation = db.G_PostGraduation.Include(g => g.CurrentStartMonth).Include(g => g.Student);
            //return View(g_PostGraduation.ToList());
        }

        // GET: PostGraduation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PostGraduation g_PostGraduation = db.PostGraduation.Find(id);
            if (g_PostGraduation == null)
            {
                return HttpNotFound();
            }
            return View(g_PostGraduation);
        }

        // GET: PostGraduation/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.StudentPrevEmpl = db.PreviousEmployment.Where(g => g.StudentID == id);
            ViewBag.StudentPublications = db.Publications.Where(g => g.StudentID == id);
            ViewBag.StudentGrants = db.Grants.Where(g => g.StudentID == id);
            ViewBag.StudentHonors = db.Honors.Where(g=>g.StudentID == id);
            ViewBag.StudentGrad = db.Graduations.Where(g => g.StudentID == id).FirstOrDefault();
            ViewBag.StudentDegreeEndSem = db.Graduations.Where(g => g.StudentID == id).FirstOrDefault().DegreeEndSemsId;
            ViewBag.StudentDegreeEndYear = db.Graduations.Where(g => g.StudentID == id).FirstOrDefault().DegreeEndYear;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            ViewBag.StudentCVs = db.Files.Where(g => g.StudentID == id);
            ViewBag.StudentNumber = db.Students.Find(id).StudentNumber;
            ViewBag.StudentEmail = db.Students.Find(id).OtherEmail;
            ViewBag.StudentPhone = db.Students.Find(id).Phone;

            ViewBag.CurrentStartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name");
            return View();
        }

        // POST: PostGraduation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,CurrentPosition,CurrentStartMonthId,CurrentStartYear")] G_PostGraduation g_PostGraduation)
        {
            if (ModelState.IsValid)
            {
                db.PostGraduation.Add(g_PostGraduation);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_PostGraduation.StudentID });
            }

            ViewBag.CurrentStartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", g_PostGraduation.CurrentStartMonthId);
            ViewBag.StudentID = g_PostGraduation.StudentID;
            return View(g_PostGraduation);
        }

        // GET: PostGraduation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            G_PostGraduation g_PostGraduation = g_Student.PostGraduation.FirstOrDefault();
            if (g_PostGraduation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentCVs = db.Files.Where(g => g.StudentID == id);
            ViewBag.CurrentStartMonthId = new SelectList(db.CommonFields.Where(g => g.Category == "Months"), "ID", "Name", g_PostGraduation.CurrentStartMonthId);
            return View(g_PostGraduation);
        }

        // POST: PostGraduation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CurrentPosition,CurrentStartMonthId,CurrentStartYear")] G_PostGraduation g_PostGraduation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_PostGraduation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = g_PostGraduation.StudentID});
            }
            ViewBag.CurrentStartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", g_PostGraduation.CurrentStartMonthId);
            ViewBag.StudentID =  g_PostGraduation.StudentID;
            return View(g_PostGraduation);
        }

        // GET: PostGraduation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PostGraduation g_PostGraduation = db.PostGraduation.Find(id);
            if (g_PostGraduation == null)
            {
                return HttpNotFound();
            }
            return View(g_PostGraduation);
        }

        // POST: PostGraduation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_PostGraduation g_PostGraduation = db.PostGraduation.Find(id);
            db.PostGraduation.Remove(g_PostGraduation);
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
