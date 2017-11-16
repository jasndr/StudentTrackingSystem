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
        public ActionResult Index()
        {
            var committeeMembers = db.CommitteeMembers.Include(g => g.Student);
            return View(committeeMembers.ToList());
        }

        // GET: CommitteeMember/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_CommitteeMember g_CommitteeMember = db.CommitteeMembers.Find(id);
            if (g_CommitteeMember == null)
            {
                return HttpNotFound();
            }
            return View(g_CommitteeMember);
        }

        // GET: CommitteeMember/Create
        public ActionResult Create(int? id)
        {
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;

            var committeeType = "";
            var degreeProgram = db.Students.Find(id).DegreePrograms.Name;
            if (degreeProgram == "MS")
            {
                committeeType = "thesis";
            } else if (degreeProgram == "PhD")
            {
                committeeType = "dissertation";
            } else
            {
                committeeType = "[thesis/dissertation]";
            }

            ViewBag.CommitteeType = committeeType;

            
            return View();
        }

        // POST: CommitteeMember/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,Name,Email,Department,University")] G_CommitteeMember g_CommitteeMember)
        {
            if (ModelState.IsValid)
            {
                db.CommitteeMembers.Add(g_CommitteeMember);
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = g_CommitteeMember.StudentID });
            }

            ViewBag.StudentID = g_CommitteeMember.StudentID;
            ViewBag.Student_FN = g_CommitteeMember.Student.FirstName;
            ViewBag.Student_LN = g_CommitteeMember.Student.LastName;
            return View(g_CommitteeMember);
        }

        // GET: CommitteeMember/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_CommitteeMember g_CommitteeMember = db.CommitteeMembers.Find(id);
            G_Student g_Student = g_CommitteeMember.Student;
            if (g_CommitteeMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = g_Student.Id;
            ViewBag.Student_FN = g_Student.FirstName;
            ViewBag.Student_LN = g_Student.LastName;

            var committeeType = "";
            var degreeProgram = g_Student.DegreePrograms.Name;
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

            return View(g_CommitteeMember);
        }

        // POST: CommitteeMember/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,Name,Email,Department,University")] G_CommitteeMember g_CommitteeMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_CommitteeMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = g_CommitteeMember.StudentID });
            }
            ViewBag.StudentID = g_CommitteeMember.StudentID;
            return View(g_CommitteeMember);
        }

        // GET: CommitteeMember/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_CommitteeMember g_CommitteeMember = db.CommitteeMembers.Find(id);
            if (g_CommitteeMember == null)
            {
                return HttpNotFound();
            }
            return View(g_CommitteeMember);
        }

        // POST: CommitteeMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_CommitteeMember g_CommitteeMember = db.CommitteeMembers.Find(id);
            db.CommitteeMembers.Remove(g_CommitteeMember);
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
