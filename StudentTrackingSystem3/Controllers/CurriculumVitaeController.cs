﻿using System;
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
            ViewBag.StudentID = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(id).FirstName;
            ViewBag.Student_LN = db.Students.Find(id).LastName;
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
                    var cv = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.CurriculumVitae,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        cv.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Student.Files = new List<G_File> { cv };
                }


                db.CurriculumVitaes.Add(g_CurriculumVitae);
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new { id = g_CurriculumVitae.StudentID});
            }

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
            G_Student g_Student = g_File.Student;

            G_CurriculumVitae g_CurriculumVitae = g_Student.CurriculumVitae.FirstOrDefault();
            if (g_CurriculumVitae == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = g_Student.Id;
            ViewBag.FileID = id;
            ViewBag.FileName = db.Files.Find(id).FileName;
            ViewBag.File = db.Files.Find(id);
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

                if (upload != null && upload.ContentLength > 0)
                {
                    
                    G_Student g_Student = db.Students.Find(g_CurriculumVitae.StudentID);
                  
                    if (g_Student.Files.Any(f => f.FileType == G_FileType.CurriculumVitae))
                    {
                        db.Files.Remove(g_Student.Files.First(f => f.FileType == G_FileType.CurriculumVitae));
                        db.Entry(g_CurriculumVitae).State = EntityState.Modified;
                        db.SaveChanges();
                        
                    }
                    var cv = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.CurriculumVitae,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        cv.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Student.Files = new List<G_File> { cv };

                    g_CurriculumVitae.Student = g_Student;
                }

                db.Entry(g_CurriculumVitae).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PostGraduation", new {id = g_CurriculumVitae.StudentID });
            }
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