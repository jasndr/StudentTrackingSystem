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
using System.IO;
using System.Data.Entity.Infrastructure;

namespace StudentTrackingSystem3.Controllers
{
    public class ActivityController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Activity
        public ActionResult Index(int? id)
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
            G_Activity g_Activity = db.Activities.Where(g => g.StudentID == g_Student.Id).FirstOrDefault();
            if (g_Activity == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Create", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });


            //var Activities = db.Activities.Include(g => g.Student);
            //return View(Activities.ToList());
        }

        // GET: Activity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Activity g_Activity = db.Activities.Find(id);
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            return View(g_Activity);
        }

        // GET: Activity/Create
        public ActionResult Create(int? id)
        {
            var student = db.Students.Find(id);
            ViewBag.StudentID = student.Id;
            ViewBag.Student_FN = student.FirstName;
            ViewBag.Student_LN = student.LastName;
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID, ActivitySummaryDesc")] G_Activity g_Activity)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Activities.Add(g_Activity);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = g_Activity.StudentID });
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and ad a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }


            //ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_Activity.StudentID);
            return View(g_Activity);
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            G_Activity g_Activity = db.Activities.Where(g => g.StudentID == g_Student.Id).FirstOrDefault();
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = g_Activity.StudentID;
            return View(g_Activity);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID, ActivitySummaryDesc")] G_Activity g_Activity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(g_Activity).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = g_Activity.StudentID });
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and ad a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }
            //ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_Activity.StudentID);
            return View(g_Activity);

        }

        // GET: Activity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Activity g_Activity = db.Activities.Find(id);
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            return View(g_Activity);
        }

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Activity g_Activity = db.Activities.Find(id);
            db.Activities.Remove(g_Activity);
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
