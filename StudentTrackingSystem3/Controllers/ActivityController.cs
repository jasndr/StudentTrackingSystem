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
    public class ActivityController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Activity
        public ActionResult Index()
        {
            var activities = db.Activities.Include(g => g.Student);
            return View(activities.ToList());
        }

        // GET: Activity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Include(s => s.Files).SingleOrDefault(s => s.Id == id);
            G_Activity g_Activity = db.Activities.Find(id);
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            return View(g_Activity);
        }

        // GET: Activity/Create
        public ActionResult Create(int? id)
        {
            ViewBag.StudentID = db.Students.Find(id).Id;
            var studentId = db.Students.Find(id).Id;
            ViewBag.Student_FN = db.Students.Find(studentId).FirstName;
            ViewBag.Student_LN = db.Students.Find(studentId).LastName;
            
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,ActivitySummaryDesc")] G_Activity g_Activity, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                
                G_Student g_Student = db.Students.Find(g_Activity.StudentID);

                if (upload != null && upload.ContentLength > 0)
                {
                    var document = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.ActivitySummaryFile,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        document.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Student.Files = new List<G_File> { document };
                }

                db.Activities.Add(g_Activity);
                db.SaveChanges();
                return RedirectToAction("Index", "Performance", new { id = g_Activity.StudentID});
            }

           
            return View(g_Activity);
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Activity g_Activity = db.Activities.Find(id);
            G_Student g_Student = g_Activity.Student;
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = g_Student.Id;
            ViewBag.FileID = g_Student.Files.FirstOrDefault().G_FileId;
            return View(g_Activity);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,ActivitySummaryFileName,ActivitySummaryFileType,ActivitySummaryDesc")] G_Activity g_Activity, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (g_Activity.Student.Files.Any(f=>f.FileType == G_FileType.ActivitySummaryFile))
                    {
                        db.Files.Remove(g_Activity.Student.Files.First(f => f.FileType == G_FileType.ActivitySummaryFile));
                    }
                    var document = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.ActivitySummaryFile,
                        ContentType =  upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        document.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Activity.Student.Files = new List<G_File> { document };

                }

                db.Entry(g_Activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Performance", new {id = g_Activity.StudentID });
            }
           // ViewBag.StudentID = new SelectList(db.Performances, "ID", "CategoryInfo", g_Activity.StudentID);
            return View(g_Activity);
        }

        // GET: Activity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Activity g_Activity = db.Activities.Find(id);
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            return View(g_Activity);
        }

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Activity g_Activity = db.Activities.Find(id);
            db.Activities.Remove(g_Activity);
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