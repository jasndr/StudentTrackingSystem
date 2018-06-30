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
    public class CommitteeMemberController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CommitteeMember
        [Authorize]
        public ActionResult Index()
        {
            var committeeMembers = db.CommitteeMembers.Include(g => g.Student);
            return View(committeeMembers.ToList());
        }

        // GET: CommitteeMember/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            if (committeeMember == null)
            {
                return HttpNotFound();
            }
            return View(committeeMember);
        }

        // GET: CommitteeMember/Create
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create(int? id)
        {
            var student = db.Students.Find(id);
            var committeeType = "";
            var degreeProgram = db.Students.Find(id).DegreePrograms.Name;
            if (degreeProgram == "MS")
            {
                committeeType = "thesis";
            }
            else if (degreeProgram == "PhD")
            {
                committeeType = "dissertation";
            }
            else
            {
                committeeType = "[thesis/dissertation]";
            }

            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.Student_FN = student.FirstName;
            ViewBag.Student_LN = student.LastName;
            ViewBag.CommitteeType = committeeType;
            
            return View();
        }

        // POST: CommitteeMember/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create([Bind(Include = "ID,StudentID,Name,Email,Department,University")] CommitteeMember committeeMember)
        {
            if (ModelState.IsValid)
            {
                db.CommitteeMembers.Add(committeeMember);
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = committeeMember.StudentID });
            }
            ViewBag.Student = committeeMember.Student;
            ViewBag.StudentID = committeeMember.StudentID;
            ViewBag.Student_FN = committeeMember.Student.FirstName;
            ViewBag.Student_LN = committeeMember.Student.LastName;
            return View(committeeMember);
        }

        // GET: CommitteeMember/Edit/5
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            Student student = committeeMember.Student;
            if (committeeMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.Student_FN = student.FirstName;
            ViewBag.Student_LN = student.LastName;

            var committeeType = "";
            var degreeProgram = student.DegreePrograms.Name;
            if (degreeProgram == "MS")
            {
                committeeType = "thesis";
            }
            else if (degreeProgram == "PhD")
            {
                committeeType = "dissertation";
            }
            else
            {
                committeeType = "[thesis/dissertation]";
            }
            ViewBag.CommitteeType = committeeType;

            return View(committeeMember);
        }

        // POST: CommitteeMember/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit([Bind(Include = "ID,StudentID,Name,Email,Department,University")] CommitteeMember committeeMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(committeeMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = committeeMember.StudentID });
            }
            ViewBag.Student = committeeMember.Student;
            ViewBag.StudentID = committeeMember.StudentID;
            return View(committeeMember);
        }

        // GET: CommitteeMember/Delete/5
        [Authorize(Roles = "Super")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            if (committeeMember == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: CommitteeMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super")]
        public ActionResult DeleteConfirmed(int id)
        {
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            Graduation graduation = db.Graduations.Find(committeeMember.Student.Graduation.FirstOrDefault().ID);
            db.CommitteeMembers.Remove(committeeMember);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This commitee member has been successfully deleted.')</script>";
            return RedirectToAction("Edit", "Graduation", new { id = graduation.ID });
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
