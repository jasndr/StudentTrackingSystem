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
    public class PrevDegreeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: PrevDegree
        public ActionResult Index()
        {
            var previousDegrees = db.PreviousDegrees.Include(g => g.DegreeTypes).Include(g => g.Student);
            return View(previousDegrees.ToList());
        }

        // GET: PrevDegree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            if (g_PrevDegree == null)
            {
                return HttpNotFound();
            }
            return View(g_PrevDegree);
        }

        // GET: PrevDegree/Create
        public ActionResult Create()
        {
            ViewBag.DegreeTypesID = new SelectList(db.CommonFields, "ID", "Name");
            ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName");
            return View();
        }

        // POST: PrevDegree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentID,DegreeTypesID,Title,CumulativeGPA,SchoolName,Major,SecondMajor,Minor,DateOfAward")] G_PrevDegree g_PrevDegree)
        {
            if (ModelState.IsValid)
            {
                db.PreviousDegrees.Add(g_PrevDegree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DegreeTypesID = new SelectList(db.CommonFields, "ID", "Name", g_PrevDegree.DegreeTypesID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_PrevDegree.StudentID);
            return View(g_PrevDegree);
        }

        // GET: PrevDegree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            if (g_PrevDegree == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeTypesID = new SelectList(db.CommonFields, "ID", "Name", g_PrevDegree.DegreeTypesID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_PrevDegree.StudentID);
            return View(g_PrevDegree);
        }

        // POST: PrevDegree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentID,DegreeTypesID,Title,CumulativeGPA,SchoolName,Major,SecondMajor,Minor,DateOfAward")] G_PrevDegree g_PrevDegree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_PrevDegree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DegreeTypesID = new SelectList(db.CommonFields, "ID", "Name", g_PrevDegree.DegreeTypesID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "FirstName", g_PrevDegree.StudentID);
            return View(g_PrevDegree);
        }

        // GET: PrevDegree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            if (g_PrevDegree == null)
            {
                return HttpNotFound();
            }
            return View(g_PrevDegree);
        }

        // POST: PrevDegree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_PrevDegree g_PrevDegree = db.PreviousDegrees.Find(id);
            db.PreviousDegrees.Remove(g_PrevDegree);
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
