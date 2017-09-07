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
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            if (g_Student == null)
            {
                return HttpNotFound();
            }
            return View(g_Student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");

            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GendersId,RaceOther,DegreeProgramsId,ConcentrationsId,TracksId,DegreeStart,DegreeEnd")] G_Student g_Student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(g_Student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");

            return View(g_Student);
        }

        [HttpDelete, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            if(g_Student == null)
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex varaible name and add a line here to write a log).
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            //G_Student g_Student = db.Students.Find(id);
            //if (g_Student == null)
            //{
            //    return HttpNotFound();
            //}

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");

            return View(g_Student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GendersId,RaceOther,DegreeProgramsId,ConcentrationsId,TracksId,DegreeStart,DegreeEnd")] G_Student g_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");

            return View(g_Student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            if (g_Student == null)
            {
                return HttpNotFound();
            }      
            return View(g_Student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Student g_Student = db.Students.Find(id);
            db.Students.Remove(g_Student);
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
