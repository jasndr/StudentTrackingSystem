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
    public class PublicationsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Publications
        public ActionResult Index()
        {
            var publications = db.Publications.Include(g => g.PubMonth).Include(g => g.Student);
            return View(publications.ToList());
        }

        // GET: Publications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Publications g_Publications = db.Publications.Find(id);
            if (g_Publications == null)
            {
                return HttpNotFound();
            }
            return View(g_Publications);
        }

        // GET: Publications/Create
        public ActionResult Create(int? id)
        {
            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name");
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,PublicationInformation,PubMonthId,PubYear")] G_Publications g_Publications)
        {
            if (ModelState.IsValid)
            {
                db.Publications.Add(g_Publications);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = g_Publications.StudentID });
            }

            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", g_Publications.PubMonthId);
            ViewBag.StudentID = g_Publications.StudentID;
            return View(g_Publications);
        }

        // GET: Publications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Publications g_Publications = db.Publications.Find(id);
            G_Student g_Student = g_Publications.Student;
            if (g_Publications == null)
            {
                return HttpNotFound();
            }
            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", g_Publications.PubMonthId);
            ViewBag.Student = g_Student;
            ViewBag.StudentID = g_Student.Id;
            return View(g_Publications);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,PublicationInformation,PubMonthId,PubYear")] G_Publications g_Publications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Publications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = g_Publications.StudentID});
            }
            ViewBag.PubMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", g_Publications.PubMonthId);
            ViewBag.StudentID = g_Publications.StudentID;
            return View(g_Publications);
        }

        // GET: Publications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Publications g_Publications = db.Publications.Find(id);
            if (g_Publications == null)
            {
                return HttpNotFound();
            }
            return View(g_Publications);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Publications g_Publications = db.Publications.Find(id);
            db.Publications.Remove(g_Publications);
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
