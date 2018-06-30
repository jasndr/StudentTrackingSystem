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
    public class CurriculumVitaeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CurriculumVitae
        public ActionResult Index()
        {
            var curriculumVitaes = db.CurriculumVitaes.Include(g => g.Student);
            return View(curriculumVitaes.ToList());
        }

        // GET: CurriculumVitae/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurriculumVitae curriculumVitae = db.CurriculumVitaes.Find(id);
            if (curriculumVitae == null)
            {
                return HttpNotFound();
            }
            return View(curriculumVitae);
        }

        // GET: CurriculumVitae/Create
        public ActionResult Create(int? id)
        {
            var student = db.Students.Find(id);

            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.Student_FN = student.FirstName;
            ViewBag.Student_LN = student.LastName;
            return View();
        }

        // POST: CurriculumVitae/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,ReceivedDate")] CurriculumVitae curriculumVitae, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Find(curriculumVitae.StudentID);

                if (upload != null && upload.ContentLength > 0)
                {
                    var cvFile = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.CurriculumVitae,
                        ContentType = upload.ContentType,
                        CurriculumVitae = curriculumVitae
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        cvFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    curriculumVitae.Files = new List<File> { cvFile };

                    //student.Files = new List<file> { cv };
                }


                db.CurriculumVitaes.Add(curriculumVitae);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = curriculumVitae.StudentID});
            }

            ViewBag.Student = curriculumVitae.Student;
            ViewBag.StudentID = curriculumVitae.StudentID;
            return View(curriculumVitae);
        }

        // GET: CurriculumVitae/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            

            CurriculumVitae curriculumVitae = file.CurriculumVitae;
            if (curriculumVitae == null)
            {
                return HttpNotFound();
            }

            Student student = curriculumVitae.Student;

            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.FileID = id;
            ViewBag.FileName = db.Files.Find(id).FileName;
            ViewBag.File = db.Files.Find(id);
            ViewBag.CurriculumVitaeID = curriculumVitae.ID;
            return View(curriculumVitae);
        }

        // POST: CurriculumVitae/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,ReceivedDate")] CurriculumVitae curriculumVitae, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Find(curriculumVitae.StudentID);
                File file = db.Files.Where(f=>f.CurriculumVitae.ID == curriculumVitae.ID).FirstOrDefault();//student.Files.FirstOrDefault(f => f.FileType == fileType.CurriculumVitae && f.StudentID == curriculumVitae.StudentID);

                if (upload != null && upload.ContentLength > 0)
                {
                  
                    if (file != null)
                    {
                        db.Files.Remove(file);
                        db.Entry(file).State = EntityState.Deleted;
                        db.Entry(curriculumVitae).State = EntityState.Modified;
                        //db.SaveChanges();
                        
                    }
                    var cvFile = new File
                    {
                      
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.CurriculumVitae,
                        ContentType = upload.ContentType,
                        CurriculumVitae = curriculumVitae
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        cvFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    curriculumVitae.Files =  new List<File> { cvFile };
                    //student.Files.Add(cv);
                    db.Entry(student).State = EntityState.Modified;
                    //db.SaveChanges();   
                }
                curriculumVitae.Student = student;
                db.Entry(curriculumVitae).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = curriculumVitae.StudentID });
            }
            ViewBag.Student = curriculumVitae.Student;
            ViewBag.StudentID =  curriculumVitae.StudentID;
            return View(curriculumVitae);
        }

        // GET: CurriculumVitae/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            CurriculumVitae curriculumVitae = db.CurriculumVitaes.Find(file.CurriculumVitaeId);
            if (curriculumVitae == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: CurriculumVitae/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            File file = db.Files.Find(id); 
            CurriculumVitae curriculumVitae = db.CurriculumVitaes.Find(file.CurriculumVitaeId);
            db.CurriculumVitaes.Remove(curriculumVitae);
            db.Files.Remove(file);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This CV has been successfully deleted.')</script>";
            return RedirectToAction("Index", "PostGraduation", new { id = curriculumVitae.StudentID });
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
