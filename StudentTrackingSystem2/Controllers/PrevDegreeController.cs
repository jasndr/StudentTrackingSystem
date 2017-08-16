using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentTrackingSystem2.Models;

namespace StudentTrackingSystem2.Controllers
{
    public class PrevDegreeController : Controller
    {
        private GraduateStudentRecord db = new GraduateStudentRecord();

        // GET: PrevDegree
        public ActionResult Index()
        {
            var graduate_PrevDegree = db.Graduate_PrevDegree.Include(g => g.Graduate_CommonFields);
            return View(graduate_PrevDegree.ToList());
        }

        // GET: PrevDegree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_PrevDegree graduate_PrevDegree = db.Graduate_PrevDegree.Find(id);
            if (graduate_PrevDegree == null)
            {
                return HttpNotFound();
            }
            return View(graduate_PrevDegree);
        }

        // GET: PrevDegree/Create
        public ActionResult Create()
        {
            ViewBag.DegreeTypeId = new SelectList(db.Graduate_CommonFields, "Id", "Name");
            return View();
        }

        // POST: PrevDegree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DegreeTypeId,Title,GPA,SchoolName,Major,SecondMajor,Minor,DateOfAward")] Graduate_PrevDegree graduate_PrevDegree)
        {
            if (ModelState.IsValid)
            {
                db.Graduate_PrevDegree.Add(graduate_PrevDegree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DegreeTypeId = new SelectList(db.Graduate_CommonFields, "Id", "Name", graduate_PrevDegree.DegreeTypeId);
            return View(graduate_PrevDegree);
        }

        // GET: PrevDegree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_PrevDegree graduate_PrevDegree = db.Graduate_PrevDegree.Find(id);
            if (graduate_PrevDegree == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeTypeId = new SelectList(db.Graduate_CommonFields, "Id", "Name", graduate_PrevDegree.DegreeTypeId);
            return View(graduate_PrevDegree);
        }

        // POST: PrevDegree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DegreeTypeId,Title,GPA,SchoolName,Major,SecondMajor,Minor,DateOfAward")] Graduate_PrevDegree graduate_PrevDegree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduate_PrevDegree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DegreeTypeId = new SelectList(db.Graduate_CommonFields, "Id", "Name", graduate_PrevDegree.DegreeTypeId);
            return View(graduate_PrevDegree);
        }

        // GET: PrevDegree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_PrevDegree graduate_PrevDegree = db.Graduate_PrevDegree.Find(id);
            if (graduate_PrevDegree == null)
            {
                return HttpNotFound();
            }
            return View(graduate_PrevDegree);
        }

        // POST: PrevDegree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graduate_PrevDegree graduate_PrevDegree = db.Graduate_PrevDegree.Find(id);
            db.Graduate_PrevDegree.Remove(graduate_PrevDegree);
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
