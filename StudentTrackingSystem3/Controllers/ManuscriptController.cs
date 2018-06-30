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
    public class ManuscriptController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Manuscript
        [Authorize]
        public ActionResult Index()
        {
            var manuscripts = db.Manuscripts.Include(g => g.Files);
            return View(manuscripts.ToList());
        }

        // GET: Manuscript/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Find(id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }

        // GET: Manuscript/Create
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create(int? id)
        {
            ViewBag.Student = db.Students.Find(id);
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
            
            return View();
        }

        // POST: Manuscript/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create([Bind(Include = "ID, StudentID, ReceivedDate")] Manuscript manuscript, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Find(manuscript.StudentID);

                if (upload != null & upload.ContentLength > 0)
                {
                    var manuscriptFile = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Manuscript,
                        ContentType = upload.ContentType,
                        Manuscript = manuscript
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        manuscriptFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    manuscript.Files = new List<File> { manuscriptFile };

                    //student.Files = new List<File> { manuscriptFile };

                }
                
                db.Manuscripts.Add(manuscript);
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = student.Id});
            }
            ViewBag.Student = manuscript.Student;
            ViewBag.StudentID = manuscript.StudentID;
            return View(manuscript);
        }

        // GET: Manuscript/Edit/5
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            
            Manuscript manuscript = file.Manuscript;
            if (manuscript == null)
            {
                return HttpNotFound();
            }

            Student student = manuscript.Student;

            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.FileID = id;
            ViewBag.FileName = db.Files.Find(id).FileName;
            ViewBag.File = db.Files.Find(id);
            ViewBag.ManuscriptID = manuscript.ID;
            return View(manuscript);
        }

        // POST: Manuscript/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit([Bind(Include = "ID, StudentID, ReceivedDate")] Manuscript manuscript, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Find(manuscript.StudentID);
                File file = db.Files.Where(f => f.Manuscript.ID == manuscript.ID).FirstOrDefault();

                if (upload != null && upload.ContentLength > 0)
                {
                    if (file != null)
                    {
                        db.Files.Remove(file);
                        db.Entry(file).State = EntityState.Deleted;
                        db.Entry(manuscript).State = EntityState.Modified;
                    }
                    var manuscriptFile = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Manuscript,
                        ContentType = upload.ContentType,
                        Manuscript = manuscript
                    };

                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        manuscriptFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    manuscript.Files = new List<File> { manuscriptFile };
                   // student.Files.Add(manuscriptFile);
                    db.Entry(student).State = EntityState.Modified;
                }
                manuscript.Student = student;
                db.Entry(manuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = manuscript.StudentID });
                    
            }
            ViewBag.Student = manuscript.Student;
            ViewBag.StudentID = manuscript.StudentID;
            return View(manuscript);
        }

        // GET: Manuscript/Delete/5
        [Authorize(Roles = "Super")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            Manuscript manuscript = db.Manuscripts.Find(file.ManuscriptId);
            if (manuscript == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: Manuscript/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super")]
        public ActionResult DeleteConfirmed(int id)
        {
            File file = db.Files.Find(id);
            Manuscript manuscript = db.Manuscripts.Find(file.ManuscriptId);
            Graduation graduation = db.Graduations.Find(manuscript.Student.Graduation.FirstOrDefault().ID);
            db.Manuscripts.Remove(manuscript);
            db.Files.Remove(file);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This manuscript has been successfully deleted.')</script>";
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
