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
    public class CourseworkController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Coursework
        public ActionResult Index(int? id, string sortOrder)
        {
            //if sortOrder is empty, then (sort by semester asc), otherwise (sort by semsester desc)
            ViewBag.Semester_SortParm = String.IsNullOrEmpty(sortOrder) ? "semester_desc" : "";

            //if sortOrder = Course, then (sort z->a), otherwise (sort a->z, should be default)
            ViewBag.Course_SortParm = sortOrder == "Course" ? "Course_desc" : "Course";

            //if sortOrder = Title, then (sort z->a), otherwise (sort a->z, should be default)
            ViewBag.Title_SortParm = sortOrder == "Title" ? "Title_desc" : "Title";

            //if sortOrder = Grade = then (sort z->a), otherwise (sort a->z, should be default)
            ViewBag.Grade_SortParm = sortOrder == "Grade" ? "Grade_desc" : "Grade";

            var coursework = db.Coursework.Include(g => g.Course).Include(g => g.Semesters).Include(g => g.Student).Where(g => g.StudentID == id);

            switch (sortOrder)
            {
                case "semester_desc":
                    coursework = coursework.OrderByDescending(s => s.Year).ThenByDescending(s => s.Semesters.DisplayOrder);
                    break;
                case "Course":
                    coursework = coursework.OrderBy(s => s.Course.CourseNum);
                    break;
                case "Course_desc":
                    coursework = coursework.OrderByDescending(s => s.Course.CourseNum);
                    break;
                case "Title":
                    coursework = coursework.OrderBy(s => s.Course.CourseName);
                    break;
                case "Title_desc":
                    coursework = coursework.OrderByDescending(s => s.Course.CourseName);
                    break;
                case "Grade":
                    coursework = coursework.OrderBy(s => s.Grade.ID);
                    break;
                case "Grade_desc":
                    coursework = coursework.OrderByDescending(s => s.Grade.ID);
                    break;
                default:
                    coursework = coursework.OrderBy(s => s.Year).ThenBy(s => s.Semesters.DisplayOrder);
                    break;
            }

            var student = db.Students.Find(id);

            ViewBag.Student = student;
            ViewBag.CurrentStudent_FirstName = student.FirstName;
            ViewBag.CurrentStudent_LastName = student.LastName;
            //ViewBag.CurrentStudent_DegreeStart = student.DegreeStart;
            // ViewBag.CurrentStudent_DegreeEnd = student.DegreeEnd;
            ViewBag.CurrentStudent_Id = (int)id;
            return View(coursework.ToList());
        }

        // GET: Coursework/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Coursework g_Coursework = db.Coursework.Find(id);
            if (g_Coursework == null)
            {
                return HttpNotFound();
            }
            return View(g_Coursework);
        }

        // GET: Coursework/Create
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create(int? id)
        {
            var student = db.Students.Find(id);

            ViewBag.Student = student;
            ViewBag.StudentID = student.Id;
            ViewBag.Student_FN = student.FirstName;
            ViewBag.Student_LN = student.LastName;
            var course =
                db.Courses.AsEnumerable().Select(s => new
                {
                    ID = s.ID,
                    CourseNum = s.CourseNum,
                    Description = string.Format("{0} - {1} ({2} credits)", s.CourseNum, s.CourseName, s.Credits)
                }).ToList();
            ViewBag.CourseID = new SelectList(course, "ID", "Description");
            //ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum", g_Coursework.CourseID);
            ViewBag.SemestersID = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");
            ViewBag.GradeID = new SelectList(db.CommonFields.Where(o => o.Category == "Grade"), "Id", "Name");
            return View();
        }

        // POST: Coursework/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Biostat, Admin, Super")]
        public ActionResult Create([Bind(Include = "ID,StudentID,SemestersID,Year,CourseID,GradeID,Comments")] G_Coursework g_Coursework)
        {
            if (ModelState.IsValid)
            {
                db.Coursework.Add(g_Coursework);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = g_Coursework.StudentID });
            }

            var course =
                db.Courses.AsEnumerable().Select(s => new
                {
                    ID = s.ID,
                    CourseNum = s.CourseNum,
                    Description = string.Format("{0} - {1} ({2} credits)", s.CourseNum, s.CourseName, s.Credits)
                }).ToList();
            ViewBag.CourseID = new SelectList(course, "ID", "Description", g_Coursework.CourseID);
            //ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum", g_Coursework.CourseID);
            ViewBag.SemestersID = new SelectList(db.CommonFields, "ID", "Name", g_Coursework.SemestersID);
            ViewBag.GradeID = new SelectList(db.CommonFields.Where(o => o.Category == "Grade"), "Id", "Name", g_Coursework.GradeID);
            ViewBag.Student = g_Coursework.Student;
            return View(g_Coursework);
        }

        // GET: Coursework/Edit/5
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Coursework g_Coursework = db.Coursework.Find(id);
            if (g_Coursework == null)
            {
                return HttpNotFound();
            }

            var course =
                db.Courses.AsEnumerable().Select(s => new
                {
                    ID = s.ID,
                    CourseNum = s.CourseNum,
                    Description = string.Format("{0} - {1} ({2} credits)", s.CourseNum, s.CourseName, s.Credits)
                }).ToList();
            ViewBag.Student = g_Coursework.Student;
            ViewBag.StudentID = g_Coursework.StudentID;
            ViewBag.CourseID = new SelectList(course, "ID", "Description", g_Coursework.CourseID);
            //ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum", g_Coursework.CourseID);
            ViewBag.SemestersID = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "ID", "Name", g_Coursework.SemestersID);
            ViewBag.GradeID = new SelectList(db.CommonFields.Where(o => o.Category == "Grade"), "Id", "Name", g_Coursework.GradeID);
            return View(g_Coursework);
        }

        // POST: Coursework/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult Edit([Bind(Include = "ID, StudentID,SemestersID,Year,CourseID,GradeID,Comments")] G_Coursework g_Coursework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Coursework).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = g_Coursework.StudentID });
            }

            var course =
                db.Courses.AsEnumerable().Select(s => new
                {
                    ID = s.ID,
                    CourseNum = s.CourseNum,
                    Description = string.Format("{0} - {1} ({2} credits)", s.CourseNum, s.CourseName, s.Credits)
                }).ToList();
            ViewBag.Student = g_Coursework.Student;
            ViewBag.CourseID = new SelectList(course, "ID", "Description", g_Coursework.CourseID);
            //ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseNum", g_Coursework.CourseID);
            ViewBag.SemestersID = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "ID", "Name", g_Coursework.SemestersID);
            ViewBag.GradeID = new SelectList(db.CommonFields.Where(o => o.Category == "Grade"), "Id", "Name", g_Coursework.GradeID);
            return View(g_Coursework);
        }

        // GET: Coursework/Delete/5
        [Authorize(Roles ="Super")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Coursework g_Coursework = db.Coursework.Find(id);
            if (g_Coursework == null)
            {
                TempData["msg"] = "<script>alert('Sorry! No record found to delete.')</script>";
                return HttpNotFound();
            }
            int sendId = (int)id;
            return DeleteConfirmed(sendId);
        }

        // POST: Coursework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Super")]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Coursework g_Coursework = db.Coursework.Find(id);
            db.Coursework.Remove(g_Coursework);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('This course has been successfully deleted.')</script>";
            return RedirectToAction("Index", "Coursework", new { id = g_Coursework.StudentID });
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
