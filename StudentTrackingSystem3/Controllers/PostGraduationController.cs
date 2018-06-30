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
            //PostGraduation postGraduation = db.Students.Find(id).PostGraduation.FirstOrDefault();

            //var postGraduation = db.PostGraduation.Where(g => g.StudentID == id).ToList();//db.Coursework.Include(g => g.Course).Include(g => g.Semesters).Include(g => g.Student).Where(g => g.StudentID == id)
            //if (postGraduation == null)
            //{
            //    return RedirectToAction("Create", new { id = id });
            //}
            //else
            //{
            //    return RedirectToAction("Edit", new { id = id });
            //}

            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.StudentPrevEmpl = db.PreviousEmployment.Where(g => g.StudentID == id);
            ViewBag.StudentPublications = db.Publications.Where(g => g.StudentID == id);
            ViewBag.StudentGrants = db.Grants.Where(g => g.StudentID == id);
            ViewBag.StudentHonors = db.Honors.Where(g => g.StudentID == id);
            ViewBag.StudentGrad = db.Graduations.Where(g => g.StudentID == id).FirstOrDefault();
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            ViewBag.StudentCVs = db.Files.Where(g => g.CurriculumVitae.StudentID == id);
            ViewBag.StudentNumber = db.Students.Find(id).StudentNumber;
            ViewBag.StudentEmail = db.Students.Find(id).OtherEmail;
            ViewBag.StudentPhone = db.Students.Find(id).Phone;

            //var postGraduation = db.PostGraduation.Include(g => g.CurrentStartMonth).Include(g => g.Student);
            var postGraduation = db.PostGraduation.Include(g=>g.Student).Include(g=>g.Student.Publications).Include(g=>g.Student.Grants).ToList();//db.Coursework.Include(g => g.Course).Include(g => g.Semesters).Include(g => g.Student).Where(g => g.StudentID == id)
            return View(postGraduation);
        }

        // GET: PostGraduation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostGraduation postGraduation = db.PostGraduation.Find(id);
            if (postGraduation == null)
            {
                return HttpNotFound();
            }
            return View(postGraduation);
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
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            ViewBag.StudentCVs = db.Files.Where(g => g.CurriculumVitae.StudentID == id);
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
        public ActionResult Create([Bind(Include = "ID,StudentID,CurrentPosition,CurrentStartMonthId,CurrentStartYear")] PostGraduation postGraduation)
        {
            if (ModelState.IsValid)
            {
                db.PostGraduation.Add(postGraduation);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = postGraduation.StudentID });
            }

            ViewBag.CurrentStartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", postGraduation.CurrentStartMonthId);
            ViewBag.Student = postGraduation.Student;
            ViewBag.StudentID = postGraduation.StudentID;
            return View(postGraduation);
        }

        // GET: PostGraduation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            PostGraduation postGraduation = student.PostGraduation.FirstOrDefault();
            if (postGraduation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student = student;
            ViewBag.StudentCVs = db.Files.Where(g => g.CurriculumVitae.StudentID == id);
            ViewBag.CurrentStartMonthId = new SelectList(db.CommonFields.Where(g => g.Category == "Months"), "ID", "Name", postGraduation.CurrentStartMonthId);
            return View(postGraduation);
        }

        // POST: PostGraduation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CurrentPosition,CurrentStartMonthId,CurrentStartYear")] PostGraduation postGraduation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postGraduation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = postGraduation.StudentID});
            }
            ViewBag.CurrentStartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", postGraduation.CurrentStartMonthId);
            ViewBag.StudentID =  postGraduation.StudentID;
            return View(postGraduation);
        }

        // GET: PostGraduation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostGraduation postGraduation = db.PostGraduation.Find(id);
            if (postGraduation == null)
            {
                return HttpNotFound();
            }
            return View(postGraduation);
        }

        // POST: PostGraduation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostGraduation postGraduation = db.PostGraduation.Find(id);
            db.PostGraduation.Remove(postGraduation);
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
