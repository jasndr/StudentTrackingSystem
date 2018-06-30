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
    public class PreviousEmploymentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: PreviousEmployment
        public ActionResult Index()
        {
            var previousEmployment = db.PreviousEmployment.Include(g => g.EndMonth).Include(g => g.StartMonth).Include(g => g.Student);
            return View(previousEmployment.ToList());
        }

        // GET: PreviousEmployment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviousEmployment previousEmployment = db.PreviousEmployment.Find(id);
            if (previousEmployment == null)
            {
                return HttpNotFound();
            }
            return View(previousEmployment);
        }

        // GET: PreviousEmployment/Create
        public ActionResult Create(int? id)
        {
            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name");
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name");
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;

            return View();
        }

        // POST: PreviousEmployment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,Position, Employer, StartMonthId,StartYear,EndMonthId,EndYear")] PreviousEmployment previousEmployment)
        {
            if (ModelState.IsValid)
            {
                db.PreviousEmployment.Add(previousEmployment);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = previousEmployment.StudentID });
            }

            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g => g.Category == "Months"), "ID", "Name", previousEmployment.EndMonthId);
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g => g.Category == "Months"), "ID", "Name", previousEmployment.StartMonthId);
            ViewBag.StudentID = db.Students.Find(previousEmployment.StudentID).Id;
            return View(previousEmployment);
        }

        // GET: PreviousEmployment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviousEmployment previousEmployment = db.PreviousEmployment.Find(id);
            Student student = previousEmployment.Student;
            if (previousEmployment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", previousEmployment.EndMonthId);
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", previousEmployment.StartMonthId);
            ViewBag.Student = previousEmployment.Student;
            ViewBag.StudentID =  previousEmployment.StudentID;
            return View(previousEmployment);
        }

        // POST: PreviousEmployment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,Position, Employer, StartMonthId,StartYear,EndMonthId,EndYear")] PreviousEmployment previousEmployment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(previousEmployment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = previousEmployment.StudentID });
            }
            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", previousEmployment.EndMonthId);
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", previousEmployment.StartMonthId);
            ViewBag.StudentID = previousEmployment.StudentID;
            return View(previousEmployment);
        }

        // GET: PreviousEmployment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviousEmployment previousEmployment = db.PreviousEmployment.Find(id);
            if (previousEmployment == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: PreviousEmployment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreviousEmployment previousEmployment = db.PreviousEmployment.Find(id);
            db.PreviousEmployment.Remove(previousEmployment);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This employment history entry has been successfully deleted.')</script>";
            return RedirectToAction("Index", "PostGraduation", new {id = previousEmployment.StudentID });
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
