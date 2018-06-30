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
            Student student = db.Students.Include(s => s.Activity) .SingleOrDefault(s => s.Id == id);
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
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
        public ActionResult Create([Bind(Include = "ID,StudentID,ActivitySummaryDesc")] Activity activity, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                
                Student student = db.Students.Find(activity.StudentID);

                if (upload != null && upload.ContentLength > 0)
                {
                    var documentFile = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.ActivitySummaryFile,
                        ContentType = upload.ContentType,
                        Activity = activity
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        documentFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    activity.Files = new List<File> { documentFile };
                    //student.Files = new List<File> { document };
                }

                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index", "Performance", new { id = activity.StudentID});
            }

           
            return View(activity);
        }

        // GET: Activity/Edit/5
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            Activity activity = file.Activity;
            if (activity == null)
            {
                return HttpNotFound();
            }
            Student student = activity.Student;

            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.FileID = id;
            ViewBag.FileName = db.Files.Find(id).FileName;
            ViewBag.File = db.Files.Find(id);
            ViewBag.ActivityID = activity.ID;
            return View(activity);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Edit([Bind(Include = "ID,StudentID,ActivitySummaryDesc")] Activity activity, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Find(activity.StudentID);
                File file = db.Files.Where(f => f.Activity.ID == activity.ID).FirstOrDefault();

                if (upload != null && upload.ContentLength > 0)
                {

                    if (file != null)
                    {
                        db.Files.Remove(file);
                        db.Entry(file).State = EntityState.Deleted;
                        db.Entry(activity).State = EntityState.Modified;
                        //db.SaveChanges();
                    }
                    
                    var documentFile = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.ActivitySummaryFile,
                        ContentType =  upload.ContentType,
                        Activity = activity/*,
                        ActivityID = activity.ID*/
                    };
                    
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        documentFile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    activity.Files = new List<File> { documentFile };
                    //activity.Files.Add(documentFile);
                    db.Entry(activity).State = EntityState.Modified;
                }
                activity.Student = student;
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Performance", new {id = activity.StudentID });
            }
            return View(activity);
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
            File file = db.Files.Find(id);
            Activity activity = db.Activities.Find(file.ActivityId);
            if (activity == null)
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
            File file = db.Files.Find(id);
            Activity activity = db.Activities.Find(file.ActivityId);
            db.Activities.Remove(activity);
            db.Files.Remove(file);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This activity summary document has been successfully deleted.')</script>";
            return RedirectToAction("Index", "Performance", new { id = activity.StudentID });
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
