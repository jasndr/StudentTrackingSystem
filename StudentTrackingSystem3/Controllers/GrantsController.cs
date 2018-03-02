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
    public class GrantsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Grants
        public ActionResult Index()
        {
            var grants = db.Grants.Include(g => g.GrantMonth).Include(g => g.Student);
            return View(grants.ToList());
        }

        // GET: Grants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Grants g_Grants = db.Grants.Find(id);
            if (g_Grants == null)
            {
                return HttpNotFound();
            }
            return View(g_Grants);
        }

        // GET: Grants/Create
        public ActionResult Create(int? id)
        {
            ViewBag.GrantMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name");
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            return View();
        }

        // POST: Grants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,GrantInformation,GrantMonthId,GrantYear")] G_Grants g_Grants)
        {
            if (ModelState.IsValid)
            {
                db.Grants.Add(g_Grants);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_Grants.StudentID });
            }

            ViewBag.GrantMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", g_Grants.GrantMonthId);
            ViewBag.Student = db.Students.Find(g_Grants.StudentID);
            ViewBag.StudentID = db.Students.Find(g_Grants.StudentID).Id;
            return View(g_Grants);
        }

        // GET: Grants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Grants g_Grants = db.Grants.Find(id);
            if (g_Grants == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrantMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", g_Grants.GrantMonthId);
            ViewBag.Student = g_Grants.Student;
            ViewBag.StudentID =  g_Grants.StudentID;
            return View(g_Grants);
        }

        // POST: Grants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,GrantInformation,GrantMonthId,GrantYear")] G_Grants g_Grants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Grants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_Grants.StudentID });
            }
            ViewBag.GrantMonthId = new SelectList(db.CommonFields.Where(o => o.Category == "Months"), "ID", "Name", g_Grants.GrantMonthId);
            ViewBag.Student = g_Grants.Student;
            ViewBag.StudentID = g_Grants.StudentID;
            return View(g_Grants);
        }

        // GET: Grants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! NO record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Grants g_Grants = db.Grants.Find(id);
            if (g_Grants == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: Grants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Grants g_Grants = db.Grants.Find(id);
            db.Grants.Remove(g_Grants);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This grant record has been successfuly deleted.')</script>";
            return RedirectToAction("Index", "PostGraduation", new { id = g_Grants.StudentID });
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
