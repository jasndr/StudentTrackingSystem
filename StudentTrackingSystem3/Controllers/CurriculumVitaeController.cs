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
            G_CurriculumVitae g_CurriculumVitae = db.CurriculumVitaes.Find(id);
            if (g_CurriculumVitae == null)
            {
                return HttpNotFound();
            }
            return View(g_CurriculumVitae);
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
        public ActionResult Create([Bind(Include = "ID,StudentID,ReceivedDate")] G_CurriculumVitae g_CurriculumVitae, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                G_Student g_Student = db.Students.Find(g_CurriculumVitae.StudentID);

                if (upload != null && upload.ContentLength > 0)
                {
                    var cvFile = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.CurriculumVitae,
                        ContentType = upload.ContentType,
                        CurriculumVitae = g_CurriculumVitae
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        cvFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_CurriculumVitae.Files = new List<G_File> { cvFile };

                    //g_Student.Files = new List<G_File> { cv };
                }


                db.CurriculumVitaes.Add(g_CurriculumVitae);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = g_CurriculumVitae.StudentID});
            }

            ViewBag.Student = g_CurriculumVitae.Student;
            ViewBag.StudentID = g_CurriculumVitae.StudentID;
            return View(g_CurriculumVitae);
        }

        // GET: CurriculumVitae/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_File g_File = db.Files.Find(id);
            

            G_CurriculumVitae g_CurriculumVitae = g_File.CurriculumVitae;
            if (g_CurriculumVitae == null)
            {
                return HttpNotFound();
            }

            G_Student g_Student = g_CurriculumVitae.Student;

            ViewBag.Student = g_Student;
            ViewBag.StudentID = g_Student.Id;
            ViewBag.FileID = id;
            ViewBag.FileName = db.Files.Find(id).FileName;
            ViewBag.File = db.Files.Find(id);
            ViewBag.CurriculumVitaeID = g_CurriculumVitae.ID;
            return View(g_CurriculumVitae);
        }

        // POST: CurriculumVitae/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,ReceivedDate")] G_CurriculumVitae g_CurriculumVitae, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                G_Student g_Student = db.Students.Find(g_CurriculumVitae.StudentID);
                G_File g_File = g_CurriculumVitae.Files.LastOrDefault();//g_Student.Files.FirstOrDefault(f => f.FileType == G_FileType.CurriculumVitae && f.StudentID == g_CurriculumVitae.StudentID);

                if (upload != null && upload.ContentLength > 0)
                {
                  
                    if (g_File != null)
                    {
                        db.Files.Remove(g_File);
                        db.Entry(g_File).State = EntityState.Deleted;
                        //db.SaveChanges();
                        
                    }
                    var cvFile = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.CurriculumVitae,
                        ContentType = upload.ContentType,
                        CurriculumVitae = g_CurriculumVitae
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        cvFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_CurriculumVitae.Files =  new List<G_File> { cvFile };
                    //g_Student.Files.Add(cv);
                    db.Entry(g_Student).State = EntityState.Modified;
                    //db.SaveChanges();   
                }
                g_CurriculumVitae.Student = g_Student;
                db.Entry(g_CurriculumVitae).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_CurriculumVitae.StudentID });
            }
            ViewBag.Student = g_CurriculumVitae.Student;
            ViewBag.StudentID =  g_CurriculumVitae.StudentID;
            return View(g_CurriculumVitae);
        }

        // GET: CurriculumVitae/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_CurriculumVitae g_CurriculumVitae = db.CurriculumVitaes.Find(id);
            if (g_CurriculumVitae == null)
            {
                return HttpNotFound();
            }
            return View(g_CurriculumVitae);
        }

        // POST: CurriculumVitae/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_CurriculumVitae g_CurriculumVitae = db.CurriculumVitaes.Find(id);
            db.CurriculumVitaes.Remove(g_CurriculumVitae);
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
