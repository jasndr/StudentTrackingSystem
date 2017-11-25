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
            G_PreviousEmployment g_PreviousEmployment = db.PreviousEmployment.Find(id);
            if (g_PreviousEmployment == null)
            {
                return HttpNotFound();
            }
            return View(g_PreviousEmployment);
        }

        // GET: PreviousEmployment/Create
        public ActionResult Create(int? id)
        {
            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name");
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name");
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
        public ActionResult Create([Bind(Include = "ID,StudentID,Position, Employer, StartMonthId,StartYear,EndMonthId,EndYear")] G_PreviousEmployment g_PreviousEmployment)
        {
            if (ModelState.IsValid)
            {
                db.PreviousEmployment.Add(g_PreviousEmployment);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_PreviousEmployment.StudentID });
            }

            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g => g.Category == "Months"), "ID", "Name", g_PreviousEmployment.EndMonthId);
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g => g.Category == "Months"), "ID", "Name", g_PreviousEmployment.StartMonthId);
            ViewBag.StudentID = db.Students.Find(g_PreviousEmployment.StudentID).Id;
            return View(g_PreviousEmployment);
        }

        // GET: PreviousEmployment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PreviousEmployment g_PreviousEmployment = db.PreviousEmployment.Find(id);
            G_Student g_Student = g_PreviousEmployment.Student;
            if (g_PreviousEmployment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", g_PreviousEmployment.EndMonthId);
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", g_PreviousEmployment.StartMonthId);
            ViewBag.StudentID =  g_PreviousEmployment.StudentID;
            return View(g_PreviousEmployment);
        }

        // POST: PreviousEmployment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,Position, Employer, StartMonthId,StartYear,EndMonthId,EndYear")] G_PreviousEmployment g_PreviousEmployment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_PreviousEmployment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_PreviousEmployment.StudentID });
            }
            ViewBag.EndMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", g_PreviousEmployment.EndMonthId);
            ViewBag.StartMonthId = new SelectList(db.CommonFields.Where(g=>g.Category == "Months"), "ID", "Name", g_PreviousEmployment.StartMonthId);
            ViewBag.StudentID = g_PreviousEmployment.StudentID;
            return View(g_PreviousEmployment);
        }

        // GET: PreviousEmployment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PreviousEmployment g_PreviousEmployment = db.PreviousEmployment.Find(id);
            if (g_PreviousEmployment == null)
            {
                return HttpNotFound();
            }
            return View(g_PreviousEmployment);
        }

        // POST: PreviousEmployment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_PreviousEmployment g_PreviousEmployment = db.PreviousEmployment.Find(id);
            db.PreviousEmployment.Remove(g_PreviousEmployment);
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
