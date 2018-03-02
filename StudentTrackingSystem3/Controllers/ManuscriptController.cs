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
        public ActionResult Index()
        {
            var manuscripts = db.Manuscripts.Include(g => g.Files);
            return View(manuscripts.ToList());
        }

        // GET: Manuscript/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Manuscript g_Manuscript = db.Manuscripts.Find(id);
            if (g_Manuscript == null)
            {
                return HttpNotFound();
            }
            return View(g_Manuscript);
        }

        // GET: Manuscript/Create
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
        public ActionResult Create([Bind(Include = "ID, StudentID, ReceivedDate")] G_Manuscript g_Manuscript, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                G_Student g_Student = db.Students.Find(g_Manuscript.StudentID);

                if (upload != null & upload.ContentLength > 0)
                {
                    var manuscriptFile = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.Manuscript,
                        ContentType = upload.ContentType,
                        Manuscript = g_Manuscript
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        manuscriptFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Manuscript.Files = new List<G_File> { manuscriptFile };

                    //g_Student.Files = new List<G_File> { manuscriptFile };

                }
                
                db.Manuscripts.Add(g_Manuscript);
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = g_Student.Id});
            }
            ViewBag.Student = g_Manuscript.Student;
            ViewBag.StudentID = g_Manuscript.StudentID;
            return View(g_Manuscript);
        }

        // GET: Manuscript/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_File g_File = db.Files.Find(id);
            
            G_Manuscript g_Manuscript = g_File.Manuscript;
            if (g_Manuscript == null)
            {
                return HttpNotFound();
            }

            G_Student g_Student = g_Manuscript.Student;

            ViewBag.Student = g_Student;
            ViewBag.StudentID = g_Student.Id;
            ViewBag.FileID = id;
            ViewBag.FileName = db.Files.Find(id).FileName;
            ViewBag.File = db.Files.Find(id);
            ViewBag.ManuscriptID = g_Manuscript.ID;
            return View(g_Manuscript);
        }

        // POST: Manuscript/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, StudentID, ReceivedDate")] G_Manuscript g_Manuscript, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                G_Student g_Student = db.Students.Find(g_Manuscript.StudentID);
                G_File g_File = db.Files.Where(f => f.Manuscript.ID == g_Manuscript.ID).FirstOrDefault();

                if (upload != null && upload.ContentLength > 0)
                {
                    if (g_File != null)
                    {
                        db.Files.Remove(g_File);
                        db.Entry(g_File).State = EntityState.Deleted;
                        db.Entry(g_Manuscript).State = EntityState.Modified;
                    }
                    var manuscript = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.Manuscript,
                        ContentType = upload.ContentType,
                        Manuscript = g_Manuscript
                    };

                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        manuscript.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Manuscript.Files = new List<G_File> { manuscript };
                   // g_Student.Files.Add(manuscript);
                    db.Entry(g_Student).State = EntityState.Modified;
                }
                g_Manuscript.Student = g_Student;
                db.Entry(g_Manuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Graduation", new { id = g_Manuscript.StudentID });
                    
            }
            ViewBag.Student = g_Manuscript.Student;
            ViewBag.StudentID = g_Manuscript.StudentID;
            return View(g_Manuscript);
        }

        // GET: Manuscript/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_File g_File = db.Files.Find(id);
            G_Manuscript g_Manuscript = db.Manuscripts.Find(g_File.ManuscriptID);
            if (g_Manuscript == null)
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
        public ActionResult DeleteConfirmed(int id)
        {
            G_File g_File = db.Files.Find(id);
            G_Manuscript g_Manuscript = db.Manuscripts.Find(g_File.ManuscriptID);
            G_Graduation g_Graduation = db.Graduations.Find(g_Manuscript.Student.Graduation.FirstOrDefault().ID);
            db.Manuscripts.Remove(g_Manuscript);
            db.Files.Remove(g_File);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This manuscript has been successfully deleted.')</script>";
            return RedirectToAction("Edit", "Graduation", new { id = g_Graduation.ID });
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
