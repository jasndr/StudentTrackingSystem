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
    public class PerformanceController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Performance
        public ActionResult Index(int? id)
        {
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.CurrentStudent_FN = db.Students.Find(id).FirstName;
            ViewBag.CurrentStudent_LN = db.Students.Find(id).LastName;

           // var coursework = db.Coursework.Include(g => g.Course).Include(g => g.Semesters).Include(g => g.Student).Where(g => g.StudentID == id)
            var performance = db.Performances.Include(p => p.AbstractStats)
                                             .Include(p => p.PublicationStats)
                                             .Include(p => p.ProposalStats)
                                             .Include(p => p.TeachingStats)
                                             .Include(g=>g.Student).Where(g=>g.StudentID == id);

            return View(performance.ToList());
        }

        // GET: Performance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Performance g_Performance = db.Performances.Find(id);
            if (g_Performance == null)
            {
                return HttpNotFound();
            }
            return View(g_Performance);
        }

        // GET: Performance/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {

            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.CurrentStudent_FN = db.Students.Find(id).FirstName;
            ViewBag.CurrentStudent_LN = db.Students.Find(id).LastName;

            ViewBag.CategoryID = new SelectList(db.CommonFields.Where(o => o.Category == "PerformanceCategory"), "Id", "Name");
            ViewBag.PublicationStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name");
            ViewBag.AbstractStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name");
            ViewBag.ProposalStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Proposal"), "Id", "Name");
            ViewBag.TeachingStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Teaching"), "Id", "Name");

            return View();
        }

        // POST: Performance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,CategoryID,CategoryInfo,PublicationStatsID,AbstractsStatID,ProposalStatsID,TeachingStatsID")] G_Performance g_Performance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Performances.Add(g_Performance);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = g_Performance.StudentID });
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }


            //View Bags for Dropdowns
            ViewBag.CategoryID = new SelectList(db.CommonFields.Where(o => o.Category == "PerformanceCategory"), "Id", "Name");
            ViewBag.PublicationStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name");
            ViewBag.AbstractStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name");
            ViewBag.ProposalStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Proposal"), "Id", "Name");
            ViewBag.TeachingStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Teaching"), "Id", "Name");

            return View(g_Performance);
        }

        // GET: Performance/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Performance g_Performance = db.Performances.Find(id);
            if (g_Performance == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudentID = g_Performance.StudentID;
            ViewBag.CurrentStudent_FN = g_Performance.Student.FirstName;
            ViewBag.CurrentStudent_LN = g_Performance.Student.LastName;

            ViewBag.CategoryID = new SelectList(db.CommonFields.Where(o => o.Category == "PerformanceCategory"), "Id", "Name", g_Performance.CategoryID);
            ViewBag.PublicationStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", g_Performance.PublicationStatsID);
            ViewBag.AbstractStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", g_Performance.AbstractStatsID);
            ViewBag.ProposalStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Proposal"), "Id", "Name", g_Performance.ProposalStatsID);
            ViewBag.TeachingStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Teaching"), "Id", "Name", g_Performance.TeachingStatsID);
            return View(g_Performance);
        }

        // POST: Performance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CategoryID,CategoryInfo,PublicationStatsID,AbstractStatsID,ProposalStatsID,TeachingStatsID")] G_Performance g_Performance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(g_Performance).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = g_Performance.StudentID });
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }
            ViewBag.CategoryID = new SelectList(db.CommonFields.Where(o => o.Category == "PerformanceCategory"), "Id", "Name", g_Performance.CategoryID);
            ViewBag.PublicationStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", g_Performance.PublicationStatsID);
            ViewBag.AbstractsStatID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", g_Performance.AbstractStatsID);
            ViewBag.ProposalStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Proposal"), "Id", "Name", g_Performance.ProposalStatsID);
            ViewBag.TeachingStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Teaching"), "Id", "Name", g_Performance.TeachingStatsID);
            return View(g_Performance);
        }

        // GET: Performance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Performance g_Performance = db.Performances.Find(id);
            if (g_Performance == null)
            {
                return HttpNotFound();
            }
            return View(g_Performance);
        }

        // POST: Performance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Performance g_Performance = db.Performances.Find(id);
            db.Performances.Remove(g_Performance);
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
