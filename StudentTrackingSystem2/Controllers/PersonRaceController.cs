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
    public class PersonRaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonRace
        public ActionResult Index()
        {
            return View(db.Graduate_PersonRace.ToList());
        }

        // GET: PersonRace/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_PersonRace graduate_PersonRace = db.Graduate_PersonRace.Find(id);
            if (graduate_PersonRace == null)
            {
                return HttpNotFound();
            }
            return View(graduate_PersonRace);
        }

        // GET: PersonRace/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonRace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentID,RaceID,Selected")] Graduate_PersonRace graduate_PersonRace)
        {
            if (ModelState.IsValid)
            {
                db.Graduate_PersonRace.Add(graduate_PersonRace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graduate_PersonRace);
        }

        // GET: PersonRace/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_PersonRace graduate_PersonRace = db.Graduate_PersonRace.Find(id);
            if (graduate_PersonRace == null)
            {
                return HttpNotFound();
            }
            return View(graduate_PersonRace);
        }

        // POST: PersonRace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentID,RaceID,Selected")] Graduate_PersonRace graduate_PersonRace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduate_PersonRace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graduate_PersonRace);
        }

        // GET: PersonRace/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate_PersonRace graduate_PersonRace = db.Graduate_PersonRace.Find(id);
            if (graduate_PersonRace == null)
            {
                return HttpNotFound();
            }
            return View(graduate_PersonRace);
        }

        // POST: PersonRace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graduate_PersonRace graduate_PersonRace = db.Graduate_PersonRace.Find(id);
            db.Graduate_PersonRace.Remove(graduate_PersonRace);
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
