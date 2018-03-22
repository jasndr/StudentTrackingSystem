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
    public class PrevDegreeController : Controller
    {
        private SchoolContext db = new SchoolContext();


        // GET: PrevDegree
        [Authorize]
        public ActionResult Index()
        {
            var previousDegrees = db.PreviousDegrees.OrderBy(g => g.DateOfAward).Include(g => g.DegreeTypes).Include(g => g.Student);
            return View(previousDegrees.ToList());
        }

        // GET: PrevDegree/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            if (g_PrevDegree == null)
            {
                return HttpNotFound();
            }
            return View(g_PrevDegree);
        }

        // GET: PrevDegree/Create
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create(int? id)
        {
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            ViewBag.DegreeTypesID = new SelectList(db.CommonFields.Where(z => z.Category == "DegreeType"), "ID", "Name");
            //ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName");
            return View();
        }

        // POST: PrevDegree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create([Bind(Include = "Id,StudentID,DegreeTypesID,Title,CumulativeGPA,SchoolName,Major,SecondMajor,Minor,DateOfAward")] G_PrevDegree g_PrevDegree)
        {
            if (ModelState.IsValid)
            {
                db.PreviousDegrees.Add(g_PrevDegree);
                db.SaveChanges();
                return RedirectToAction("Edit", "Student", new { id = g_PrevDegree.StudentID });
            }
            ViewBag.DegreeTypesID = new SelectList(db.CommonFields.Where(z => z.Category == "DegreeType"), "ID", "Name", g_PrevDegree.DegreeTypesID);
            ViewBag.Student = g_PrevDegree.Student;
            //ViewBag.StudentID = g_PrevDegree.StudentID;
            return View(g_PrevDegree);
        }

        // GET: PrevDegree/Edit/5
        [Authorize(Roles ="Admin, Super")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            if (g_PrevDegree == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeTypesID = new SelectList(db.CommonFields.Where(z => z.Category == "DegreeType"), "ID", "Name", g_PrevDegree.DegreeTypesID);
            ViewBag.Student = g_PrevDegree.Student;
            ViewBag.StudentID = g_PrevDegree.StudentID;
            return View(g_PrevDegree);
        }

        // POST: PrevDegree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit([Bind(Include = "Id,StudentID,DegreeTypesID,Title,CumulativeGPA,SchoolName,Major,SecondMajor,Minor,DateOfAward")] G_PrevDegree g_PrevDegree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_PrevDegree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Student", new { id = g_PrevDegree.StudentID });
            }
            ViewBag.DegreeTypesID = new SelectList(db.CommonFields, "ID", "Name", g_PrevDegree.DegreeTypesID);
            ViewBag.StudentID = g_PrevDegree.StudentID;//new SelectList(db.Students, "Id", "FirstName", g_PrevDegree.StudentID);
            return View(g_PrevDegree);
        }

        // GET: PrevDegree/Delete/5
        [Authorize(Roles ="Super")]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry!  No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            if (g_PrevDegree == null)
            {
                TempData["msg"] = "<script>alert('Sorry!  No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);

        }

        // POST: PrevDegree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super")]
        public ActionResult DeleteConfirmed(int id)
        {
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            db.PreviousDegrees.Remove(g_PrevDegree);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This degree has been successfully deleted.')</script>";
            return RedirectToAction("Edit", "Student", new { id = g_PrevDegree.StudentID });
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
