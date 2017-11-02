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
            G_Honors g_Honors = db.Honors.Find(id);
            if (g_Honors == null)
            {
                return HttpNotFound();
            }
            return View(g_Honors);
        }

        // GET: Honors/Create
        public ActionResult Create(int? id)
        {
            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name");
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
        public ActionResult Create([Bind(Include = "ID,StudentID,HonorInformation,HonorMonthId,HonorYear")] G_Honors g_Honors)
        {
            if (ModelState.IsValid)
            {
                db.Honors.Add(g_Honors);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = g_Honors.StudentID});
            }

            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", g_Honors.HonorMonthId);
            ViewBag.StudentID = g_Honors.StudentID;
            return View(g_Honors);
        }

        // GET: Honors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Honors g_Honors = db.Honors.Find(id);
            if (g_Honors == null)
            {
                return HttpNotFound();
            }
            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o=>o.Category == "Months"), "ID", "Name", g_Honors.HonorMonthId);
            ViewBag.StudentID = g_Honors.StudentID;
            return View(g_Honors);
        }

        // POST: Honors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,HonorInformation,HonorMonthId,HonorYear")] G_Honors g_Honors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Honors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_Honors.StudentID });
            }
            ViewBag.HonorMonthId = new SelectList(db.CommonFields.Where(o => o.Category == "Months"), "ID", "Name", g_Honors.HonorMonthId);
            ViewBag.StudentID = g_Honors.StudentID;
            return View(g_Honors);
        }

        // GET: Honors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Honors g_Honors = db.Honors.Find(id);
            if (g_Honors == null)
            {
                return HttpNotFound();
            }
            return View(g_Honors);
        }

        // POST: Honors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Honors g_Honors = db.Honors.Find(id);
            db.Honors.Remove(g_Honors);
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
