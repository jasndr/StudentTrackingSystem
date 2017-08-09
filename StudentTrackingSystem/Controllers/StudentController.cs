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
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Graduate_Student.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_Student graduate_Student = db.Graduate_Student.Find(id);
            if (graduate_Student == null)
            {
                return HttpNotFound();
            }
            return View(graduate_Student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GenderId,DegreeId,RaceEthnicityId,RaceOther,DegreeProgramId,ConcentrationId,TrackId,DegreeStart,DegreeEnd")] Graduate_Student graduate_Student)
        {
            if (ModelState.IsValid)
            {
                db.Graduate_Student.Add(graduate_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graduate_Student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_Student graduate_Student = db.Graduate_Student.Find(id);
            if (graduate_Student == null)
            {
                return HttpNotFound();
            }
            return View(graduate_Student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GenderId,DegreeId,RaceEthnicityId,RaceOther,DegreeProgramId,ConcentrationId,TrackId,DegreeStart,DegreeEnd")] Graduate_Student graduate_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduate_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graduate_Student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_Student graduate_Student = db.Graduate_Student.Find(id);
            if (graduate_Student == null)
            {
                return HttpNotFound();
            }
            return View(graduate_Student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graduate_Student graduate_Student = db.Graduate_Student.Find(id);
            db.Graduate_Student.Remove(graduate_Student);
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
