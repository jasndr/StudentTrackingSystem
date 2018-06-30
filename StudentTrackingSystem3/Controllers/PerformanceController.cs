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
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            Student student = db.Students.Find(id);
            ViewBag.StudentFiles = db.Files.Where(g=>g.Activity.StudentID == id);
            ViewBag.CurrentStudent_FN = db.Students.Find(id).FirstName;
            ViewBag.CurrentStudent_LN = db.Students.Find(id).LastName;

            // var coursework = db.Coursework.Include(g => g.Course).Include(g => g.Semesters).Include(g => g.Student).Where(g => g.StudentID == id)
            var performance = db.Performances.Include(p => p.AbstractStats)
                                             .Include(p => p.PublicationStats)
                                             .Include(p => p.ProposalStats)
                                             .Include(p => p.TeachingStats)
                                             .Include(g => g.Student).Where(g => g.StudentID == id);
                                            // .Include(s=>s.Studen.Files).Where(g => g.StudentID == id);

            return View(performance.ToList());
        }

        // GET: Performance/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            return View(performance);
        }

        // GET: Performance/Create
        [HttpGet]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create(int? id)
        {
            ViewBag.Student = db.Students.Find(id);
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
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create([Bind(Include = "ID,StudentID,CategoryID,CategoryInfo,PublicationStatsID,AbstractsStatID,ProposalStatsID,TeachingStatsID")] Performance performance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Performances.Add(performance);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = performance.StudentID });
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
            ViewBag.Student = performance.Student;
            return View(performance);
        }

        // GET: Performance/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student = performance.Student;
            ViewBag.StudentID = performance.StudentID;
            ViewBag.CurrentStudent_FN = performance.Student.FirstName;
            ViewBag.CurrentStudent_LN = performance.Student.LastName;

            ViewBag.CategoryID = new SelectList(db.CommonFields.Where(o => o.Category == "PerformanceCategory"), "Id", "Name", performance.CategoryID);
            ViewBag.PublicationStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", performance.PublicationStatsID);
            ViewBag.AbstractStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", performance.AbstractStatsID);
            ViewBag.ProposalStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Proposal"), "Id", "Name", performance.ProposalStatsID);
            ViewBag.TeachingStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Teaching"), "Id", "Name", performance.TeachingStatsID);

            return View(performance);
        }

        // POST: Performance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CategoryID,CategoryInfo,PublicationStatsID,AbstractStatsID,ProposalStatsID,TeachingStatsID")] Performance performance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(performance).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = performance.StudentID });
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }
            ViewBag.Student = performance.Student;
            ViewBag.CategoryID = new SelectList(db.CommonFields.Where(o => o.Category == "PerformanceCategory"), "Id", "Name", performance.CategoryID);
            ViewBag.PublicationStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", performance.PublicationStatsID);
            ViewBag.AbstractsStatID = new SelectList(db.CommonFields.Where(o => o.Category == "Publication"), "Id", "Name", performance.AbstractStatsID);
            ViewBag.ProposalStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Proposal"), "Id", "Name", performance.ProposalStatsID);
            ViewBag.TeachingStatsID = new SelectList(db.CommonFields.Where(o => o.Category == "Teaching"), "Id", "Name", performance.TeachingStatsID);
            return View(performance);
        }

        // GET: Performance/Delete/5
        [Authorize(Roles = "Super")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry!  No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                TempData["msg"] = "<script>alert('Sorry!  No record found to delete.')</script>";
                return HttpNotFound();
            }
         
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        [Authorize(Roles = "Super")]
        // POST: Performance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Performance performance = db.Performances.Find(id);
            db.Performances.Remove(performance);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This performance record has been successfully deleted.')</script>";
            return RedirectToAction("Index", "Performance", new { id = performance.StudentID });
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
