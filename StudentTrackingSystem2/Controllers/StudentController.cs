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
    public class StudentController : Controller
    {
        private GraduateStudentRecord db = new GraduateStudentRecord();

        // GET: Student
        public ActionResult Index()
        {
            var graduate_Student = db.Graduate_Student.Include(g => g.Graduate_CommonFields).Include(g => g.Graduate_CommonFields1).Include(g => g.Graduate_CommonFields2).Include(g => g.Graduate_CommonFields3).Include(g => g.Graduate_PrevDegree);
            return View(graduate_Student.ToList());
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
            ViewBag.ConcentrationId = new SelectList(db.Graduate_CommonFields.Where(o=>o.Category=="Concentration"), "Id", "Name");
            ViewBag.DegreeProgramId = new SelectList(db.Graduate_CommonFields.Where(o=>o.Category=="DegreeProgram"), "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Graduate_CommonFields.Where(o=>o.Category=="Gender"), "Id", "Name");
            //ViewBag.RaceEthnicityId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Race/Ethnicity"), "Id", "Name");
            ViewBag.TrackId = new SelectList(db.Graduate_CommonFields.Where(o=>o.Category=="Track"), "Id", "Name");
            ViewBag.DegreeId = new SelectList(db.Graduate_PrevDegree, "Id", "Title");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GenderId,DegreeId,RaceOther,DegreeProgramId,ConcentrationId,TrackId,DegreeStart,DegreeEnd")] Graduate_Student graduate_Student)
        {
            if (ModelState.IsValid)
            {
                db.Graduate_Student.Add(graduate_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConcentrationId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name", graduate_Student.ConcentrationId);
            ViewBag.DegreeProgramId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name", graduate_Student.DegreeProgramId);
            ViewBag.GenderId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Gender"), "Id", "Name", graduate_Student.GenderId);
            //ViewBag.RaceEthnicityId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Race/Ethnicity"), "Id", "Name", graduate_Student.RaceEthnicityId);
            ViewBag.TrackId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Track"), "Id", "Name", graduate_Student.TrackId);
            ViewBag.DegreeId = new SelectList(db.Graduate_PrevDegree, "Id", "Title", graduate_Student.DegreeId);
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
            ViewBag.ConcentrationId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name", graduate_Student.ConcentrationId);
            ViewBag.DegreeProgramId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name", graduate_Student.DegreeProgramId);
            ViewBag.GenderId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Gender"), "Id", "Name", graduate_Student.GenderId);
            //ViewBag.RaceEthnicityId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Race/Ethnicity"), "Id", "Name", graduate_Student.RaceEthnicityId);
            ViewBag.TrackId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Track"), "Id", "Name", graduate_Student.TrackId);
            ViewBag.DegreeId = new SelectList(db.Graduate_PrevDegree, "Id", "Title", graduate_Student.DegreeId);
            return View(graduate_Student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GenderId,DegreeId,RaceOther,DegreeProgramId,ConcentrationId,TrackId,DegreeStart,DegreeEnd")] Graduate_Student graduate_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduate_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConcentrationId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name", graduate_Student.ConcentrationId);
            ViewBag.DegreeProgramId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name", graduate_Student.DegreeProgramId);
            ViewBag.GenderId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Gender"), "Id", "Name", graduate_Student.GenderId);
            //ViewBag.RaceEthnicityId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Race/Ethnicity"), "Id", "Name", graduate_Student.RaceEthnicityId);
            ViewBag.TrackId = new SelectList(db.Graduate_CommonFields.Where(o => o.Category == "Track"), "Id", "Name", graduate_Student.TrackId);
            ViewBag.DegreeId = new SelectList(db.Graduate_PrevDegree, "Id", "Title", graduate_Student.DegreeId);
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
