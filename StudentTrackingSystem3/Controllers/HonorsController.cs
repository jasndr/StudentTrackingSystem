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
    public class HonorsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Honors
        public ActionResult Index()
        {
            var honors = db.Honors.Include(g => g.HonorMonth).Include(g => g.Student);
            return View(honors.ToList());
        }

        // GET: Honors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honors honors = db.Honors.Find(id);
            if (honors == null)
            {
                return HttpNotFound();
            }
            return View(honors);
        }

        // GET: Honors/Create
        public ActionResult Create(int? id)
        {
            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name");
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            return View();
        }

        // POST: Honors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,HonorInformation,HonorMonthId,HonorYear")] Honors honors)
        {
            if (ModelState.IsValid)
            {
                db.Honors.Add(honors);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = honors.StudentID});
            }

            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", honors.HonorMonthId);
            ViewBag.Student = honors.Student;
            ViewBag.StudentID = honors.StudentID;
            return View(honors);
        }

        // GET: Honors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honors honors = db.Honors.Find(id);
            if (honors == null)
            {
                return HttpNotFound();
            }
            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", honors.HonorMonthId);
            ViewBag.Student = honors.Student;
            ViewBag.StudentID = honors.StudentID;
            return View(honors);
        }

        // POST: Honors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,HonorInformation,HonorMonthId,HonorYear")] Honors honors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(honors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = honors.StudentID });
            }
            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o => o.Category == "Months"), "ID", "Name", honors.HonorMonthId);
            ViewBag.Student = honors.Student;
            ViewBag.StudentID = honors.StudentID;
            return View(honors);
        }

        // GET: Honors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honors honors = db.Honors.Find(id);
            if (honors == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: Honors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Honors honors = db.Honors.Find(id);
            db.Honors.Remove(honors);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This honor/award entry has been successfully deleted.')</script>";
            return RedirectToAction("Index", "PostGraduation", new { id = honors.StudentID });
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
