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
    public class GraduationController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Graduation
        public ActionResult Index(int? id)
        {
            //Create new entry if not can't find a graduation record for studentid

            G_Graduation g_Graduation = db.Students.Find(id).Graduation.FirstOrDefault();
            if (g_Graduation == null)
            {
                return RedirectToAction("Create", new { id = id });
            }
            else
            {
                return RedirectToAction("Edit", new { id = id });
            }

           // var graduations = db.Graduations.Include(g => g.DegreeEndSems).Include(g => g.Form2Result).Include(g => g.Form2Type).Include(g => g.Student);
            //return View(graduations.ToList());
        }

        // GET: Graduation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Graduation g_Graduation = db.Graduations.Find(id);
            if (g_Graduation == null)
            {
                return HttpNotFound();
            }
            return View(g_Graduation);
        }

        // GET: Graduation/Create
        public ActionResult Create(int? id)
        {

            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.StudentCMsFirstOrDefault = db.CommitteeMembers.Where(g => g.StudentID == id).FirstOrDefault();
            ViewBag.StudentCMs = db.CommitteeMembers.Where(g => g.StudentID == id);
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            
            ViewBag.DegreeEndSemsId = new SelectList(db.CommonFields.Where(s => s.Category=="Season"), "ID", "Name");
            ViewBag.QualifierResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name");
            ViewBag.Qualifier2ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name");
            ViewBag.Form2TypeId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Type"), "ID", "Name");
            ViewBag.Form2ResultId = new SelectList(db.CommonFields.Where(s=>s.Category=="Form2Result"), "ID", "Name");
            ViewBag.Form3ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Result"), "ID", "Name");
            ViewBag.CommitteeTypeId = new SelectList(db.CommonFields.Where(s => s.Category == "CommitteeType"), "ID", "Name");
            
            return View();
        }

        // POST: Graduation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "ID,StudentID,DegreeEndSemsId,DegreeEndYear,QualifierResultId,Qualifier2ResultId,DateOfQualification,Form2TypeId,Form2Title,Form2Date,Form2ResultId,CommitteeTypeID,AdvisorName,AdvisorEmail,AdvisorDepartment,AdvisorUniversity,Form3Title,Form3Date,Form3ResultId")]*/ G_Graduation g_Graduation)
        {
            if (ModelState.IsValid)
            {
                db.Graduations.Add(g_Graduation);
                db.SaveChanges();
                return RedirectToAction("Edit", "Graduation",  new { id = g_Graduation.StudentID});
            }

            ViewBag.DegreeEndSemsId = new SelectList(db.CommonFields.Where(s => s.Category == "Season"), "ID", "Name");
            ViewBag.QualifierResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name");
            ViewBag.Qualifier2ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name");
            ViewBag.Form2TypeId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Type"), "ID", "Name");
            ViewBag.Form2ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Result"), "ID", "Name");
            ViewBag.Form3ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Result"), "ID", "Name");
            ViewBag.CommitteeTypeID = new SelectList(db.CommonFields.Where(s => s.Category == "CommitteeType"), "ID", "Name");
            return View(g_Graduation);
        }

        // GET: Graduation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            G_Graduation g_Graduation = db.Graduations.Find(g_Student.Graduation.FirstOrDefault().ID);
            if (g_Graduation == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudentID = g_Student.Id;
            ViewBag.StudentCMs = db.CommitteeMembers.Where(g => g.StudentID == id);
            ViewBag.Student_FN = g_Student.FirstName;
            ViewBag.Student_LN = g_Student.LastName;

            ViewBag.DegreeEndSemsId = new SelectList(db.CommonFields.Where(s => s.Category == "Season"), "ID", "Name", g_Graduation.DegreeEndSemsId);
            ViewBag.QualifierResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name", g_Graduation.QualifierResultId);
            ViewBag.Qualifier2ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name", g_Graduation.Qualifier2ResultId);
            ViewBag.Form2TypeId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Type"), "ID", "Name", g_Graduation.Form2TypeId);
            ViewBag.Form2ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Result"), "ID", "Name", g_Graduation.Form2ResultId);
            ViewBag.Form3ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Result"), "ID", "Name", g_Graduation.Form3ResultId);
            ViewBag.CommitteeTypeID = new SelectList(db.CommonFields.Where(s => s.Category == "CommitteeType"), "ID", "Name", g_Graduation.CommitteeTypeID);
            return View(g_Graduation);
        }

        // POST: Graduation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,DegreeEndSemsId,DegreeEndYear,QualifierResultId,Qualifier2ResultId,DateOfQualification,Form2TypeId,Form2Title,Form2Date,Form2ResultId,CommitteeTypeID,AdvisorName,AdvisorEmail,AdvisorDepartment,AdvisorUniversity,Form3Title,Form3Date,Form3ResultId")] G_Graduation g_Graduation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Graduation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Graduation", g_Graduation.StudentID);
            }
            ViewBag.DegreeEndSemsId = new SelectList(db.CommonFields.Where(s => s.Category == "Season"), "ID", "Name", g_Graduation.DegreeEndSemsId);
            ViewBag.QualifierResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name", g_Graduation.QualifierResultId);
            ViewBag.Qualifier2ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "QualifierResult"), "ID", "Name", g_Graduation.Qualifier2ResultId);
            ViewBag.Form2TypeId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Type"), "ID", "Name", g_Graduation.Form2TypeId);
            ViewBag.Form2ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Result"), "ID", "Name", g_Graduation.Form2ResultId);
            ViewBag.Form3ResultId = new SelectList(db.CommonFields.Where(s => s.Category == "Form2Result"), "ID", "Name", g_Graduation.Form3ResultId);
            ViewBag.CommitteeTypeId = new SelectList(db.CommonFields.Where(s => s.Category == "CommitteeType"), "ID", "Name", g_Graduation.CommitteeTypeID);
            return View(g_Graduation);
        }

        // GET: Graduation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Graduation g_Graduation = db.Graduations.Find(id);
            if (g_Graduation == null)
            {
                return HttpNotFound();
            }
            return View(g_Graduation);
        }

        // POST: Graduation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Graduation g_Graduation = db.Graduations.Find(id);
            db.Graduations.Remove(g_Graduation);
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
