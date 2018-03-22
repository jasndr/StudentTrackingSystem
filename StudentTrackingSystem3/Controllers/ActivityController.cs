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
    public class ActivityController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Activity
        [Authorize]
        public ActionResult Index()
        {
            var activities = db.Activities.Include(g => g.Student);
            return View(activities.ToList());
        }

        // GET: Activity/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Include(s => s.Activity) .SingleOrDefault(s => s.Id == id);
            G_Activity g_Activity = db.Activities.Find(id);
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            return View(g_Activity);
        }

        // GET: Activity/Create
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create(int? id)
        {
            var student = db.Students.Find(id);
            var studentId = student.Id;

            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.Student_FN = student.FirstName;
            ViewBag.Student_LN = student.LastName;
            
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create([Bind(Include = "ID,StudentID,ActivitySummaryDesc")] G_Activity g_Activity, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                
                G_Student g_Student = db.Students.Find(g_Activity.StudentID);

                if (upload != null && upload.ContentLength > 0)
                {
                    var documentFile = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.ActivitySummaryFile,
                        ContentType = upload.ContentType,
                        Activity = g_Activity
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        documentFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Activity.Files = new List<G_File> { documentFile };
                    //g_Student.Files = new List<G_File> { document };
                }

                db.Activities.Add(g_Activity);
                db.SaveChanges();
                return RedirectToAction("Index", "Performance", new { id = g_Activity.StudentID});
            }

           
            return View(g_Activity);
        }

        // GET: Activity/Edit/5
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_File g_File = db.Files.Find(id);
            G_Activity g_Activity = g_File.Activity;
            if (g_Activity == null)
            {
                return HttpNotFound();
            }
            G_Student g_Student = g_Activity.Student;

            ViewBag.Student = g_Student;
            ViewBag.StudentID = g_Student.Id;
            ViewBag.FileID = id;
            ViewBag.FileName = db.Files.Find(id).FileName;
            ViewBag.File = db.Files.Find(id);
            ViewBag.ActivityID = g_Activity.ID;
            return View(g_Activity);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Edit([Bind(Include = "ID,StudentID,ActivitySummaryDesc")] G_Activity g_Activity, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                G_Student g_Student = db.Students.Find(g_Activity.StudentID);
                G_File g_File = db.Files.Where(f => f.Activity.ID == g_Activity.ID).FirstOrDefault();

                if (upload != null && upload.ContentLength > 0)
                {

                    if (g_File != null)
                    {
                        db.Files.Remove(g_File);
                        db.Entry(g_File).State = EntityState.Deleted;
                        db.Entry(g_Activity).State = EntityState.Modified;
                        //db.SaveChanges();
                    }
                    
                    var documentFile = new G_File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = G_FileType.ActivitySummaryFile,
                        ContentType =  upload.ContentType,
                        Activity = g_Activity/*,
                        ActivityID = g_Activity.ID*/
                    };
                    
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        documentFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    g_Activity.Files = new List<G_File> { documentFile };
                    //g_Activity.Files.Add(documentFile);
                    db.Entry(g_Activity).State = EntityState.Modified;
                }
                g_Activity.Student = g_Student;
                db.Entry(g_Activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Performance", new {id = g_Activity.StudentID });
            }
            return View(g_Activity);
        }

        // GET: Activity/Delete/5
        [Authorize(Roles = "Super")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_File g_File = db.Files.Find(id);
            G_Activity g_Activity = db.Activities.Find(g_File.ActivityID);
            if (g_Activity == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super")]
        public ActionResult DeleteConfirmed(int id)
        {
            G_File g_File = db.Files.Find(id);
            G_Activity g_Activity = db.Activities.Find(g_File.ActivityID);
            db.Activities.Remove(g_Activity);
            db.Files.Remove(g_File);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This activity summary document has been successfully deleted.')</script>";
            return RedirectToAction("Index", "Performance", new { id = g_Activity.StudentID });
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
