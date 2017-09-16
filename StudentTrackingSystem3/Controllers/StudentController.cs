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
using StudentTrackingSystem3.ViewModels;

namespace StudentTrackingSystem3.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            if (g_Student == null)
            {
                return HttpNotFound();
            }
            return View(g_Student);
        }


        // GET: Student/Create
        public ActionResult Create()
        {

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");

            return View(GetRacesInitialModel());
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GendersId,RaceOther,DegreeProgramsId,ConcentrationsId,TracksId,DegreeStart,DegreeEnd")] G_Student g_Student,*/UltimateViewModel ultimate)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //Add recorded student
                    db.Students.Add(ultimate.G_Student);

                    ultimate.RacesViewModel.AvailableRaces = db.Races.ToList();

                    //For current student, add to personRaceTable, student id number and postedRace number
                    foreach (var item in ultimate.RacesViewModel.PostedRaces.RaceIDs)
                    {
                        var personRace = new G_PersonRaces();
                        int raceId = Int32.Parse(item);
                        var race = db.Races.Where(s => s.Id == raceId).ToList().Single();
                        personRace.Student = ultimate.G_Student;
                        personRace.Race = race;
                        personRace.IsSelectedPR = true;
                        db.PersonRaces.Add(personRace);
                        db.SaveChanges();
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");



            return View(GetRacesModel(ultimate));
        }



        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UltimateViewModel ultimate = new UltimateViewModel();
            var rvm = new RacesViewModel();
            rvm.SelectedRaces = new List<G_Races>();

            G_Student g_Student = db.Students.Find(id);
            if (g_Student == null)
            {
                return HttpNotFound();
            }

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");

            //Initialize selectedRaces
            var racesToPost = new List<G_Races>();
            foreach (var item in g_Student.PersonRaces.Where(x => x.StudentID == id && x.IsSelectedPR.Equals(true)))
            {
                racesToPost.Add(item.Race);
            }

            //setup ultimate view model
            rvm.SelectedRaces = racesToPost;
            ultimate.RacesViewModel = rvm;
            ultimate.G_Student = g_Student;

            return View(GetRacesInitialModel(ultimate, id));
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GendersId,RaceOther,DegreeProgramsId,ConcentrationsId,TracksId,DegreeStart,DegreeEnd")] G_Student g_Student*/UltimateViewModel ultimate, PostedRaces postedRaces)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ultimate.G_Student).State = EntityState.Modified;

                    //Initiate postedRaces;
                    postedRaces = ultimate.RacesViewModel.PostedRaces;

                    //Create current/previously-checked race list
                    var currPRList = db.PersonRaces.Where(s => s.StudentID == ultimate.G_Student.Id && s.IsSelectedPR.Equals(true)).ToList();
                    var currRaceList = new List<G_Races>();
                    foreach (var item in currPRList)
                    {
                        currRaceList.Add(item.Race);

                    }
                    //Create new checked race list
                    var newList = new List<G_Races>();
                    foreach (var item in postedRaces.RaceIDs)
                    {
                        int raceId = Int32.Parse(item);
                        var race = db.Races.Where(s => s.Id == raceId).ToList().Single();
                        newList.Add(race);
                    }

                    //Iterate through new items; if there are no new items in current list, add them
                    foreach (var nItem in newList)
                    {
                        if (!currRaceList.Contains(nItem))
                        {
                            var personRace = new G_PersonRaces();
                            int raceId = nItem.Id;
                            var race = db.Races.Where(s => s.Id == raceId).ToList().Single();
                            personRace.Student = ultimate.G_Student;
                            personRace.Race = race;
                            personRace.IsSelectedPR = true;
                            db.PersonRaces.Add(personRace);
                            db.SaveChanges();
                        }
                    }

                    //Iterate through the current items; if there are no item in new list, delete them
                    foreach (var cItem in currRaceList)
                    {
                        if (!newList.Contains(cItem))
                        {
                            var race = db.Races.Where(s => s.Id == cItem.Id).ToList().Single();

                            var prEntity = db.PersonRaces.SingleOrDefault(s => s.StudentID == ultimate.G_Student.Id && s.RaceID == cItem.Id && s.IsSelectedPR.Equals(true));
                            prEntity.IsSelectedPR = false;

                            db.SaveChanges();
                        }
                    }


                    ultimate.RacesViewModel.SelectedRaces = newList;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and ad a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.ConcentrationsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Concentration"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");

            return View(GetRacesModel(ultimate, postedRaces));
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Student g_Student = db.Students.Find(id);
            if (g_Student == null)
            {
                return HttpNotFound();
            }
            return View(g_Student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Student g_Student = db.Students.Find(id);
            db.Students.Remove(g_Student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Setup view model after post, where user select fruit data (For create view - httppost)
        /// </summary>
        /// <param name="postedRaces"></param>
        /// <returns>UltimateViewModel</returns>
        private UltimateViewModel GetRacesModel(UltimateViewModel ultimate)
        {

            //Setup properties
            var rvm = ultimate.RacesViewModel;
            var selectedRaces = rvm.SelectedRaces;
            var postedRaces = rvm.PostedRaces;
            var postedRaceIds = new string[0];
            if (postedRaces == null) postedRaces = new PostedRaces();

            //Save selected ids (if array of posted exists and not empty)
            if (postedRaces.RaceIDs != null && postedRaces.RaceIDs.Any())
            {
                postedRaceIds = postedRaces.RaceIDs;
            }

            //Create list of races (if any selected ids saved)
            if (postedRaceIds.Any())
            {
                selectedRaces = db.Races.Where(x => postedRaceIds.Any(s => x.Id.ToString().Equals(s))).ToList();

            }

            //Setup view model
            rvm.AvailableRaces = db.Races.ToList();//RaceRepository.GetAll().ToList();
            rvm.SelectedRaces = selectedRaces;
            rvm.PostedRaces = postedRaces;

            ultimate.RacesViewModel = rvm;

            return ultimate;

        }

        /// <summary>
        /// Setup view model after post, where user select fruit data (For edit view - httppost)
        /// </summary>
        /// <param name="postedRaces"></param>
        /// <returns></returns>
        private UltimateViewModel GetRacesModel(UltimateViewModel ultimate, PostedRaces postedRaces)
        {
            //Setup properties
            var rvm = ultimate.RacesViewModel;
            var selectedRaces = rvm.SelectedRaces;
            var postedRaceIds = new string[0];
            postedRaces = rvm.PostedRaces;
            if (postedRaces == null) postedRaces = new PostedRaces();

            //Save selected ids (if array of posted exists and not empty)
            if (postedRaces.RaceIDs != null && postedRaces.RaceIDs.Any())
            {
                postedRaceIds = postedRaces.RaceIDs;
            }

            //Create list of fruits (if any selected ids saved)
            //if (postedRaceIds.Any())
            //{
            //    //selectedRaces = RaceRepository.GetAll().Where(x => postedRaceIds.Any(s => x.Id.ToString().Equals(s))).ToList();
            //    selectedRaces = db.Races.Where(x => postedRaceIds.Any(s => x.Id.ToString().Equals(s))).ToList();
            //}

            //Setup view model
            rvm.AvailableRaces = db.Races.ToList();//RaceRepository.GetAll().ToList();
            rvm.SelectedRaces = selectedRaces;
            rvm.PostedRaces = postedRaces;

            ultimate.RacesViewModel = rvm;

            return ultimate;

        }

        /// <summary>
        /// Initial view model of all races (create view - httpget)
        /// </summary>
        /// <returns>UltimateViewModel</returns>
        private UltimateViewModel GetRacesInitialModel()
        {
            //setup properties
            var model = new UltimateViewModel();
            var rvm = new RacesViewModel();
            var selectedRaces = new List<G_Races>();

            //setup view model
            rvm.AvailableRaces = RaceRepository.GetAll().ToList();
            rvm.SelectedRaces = selectedRaces;

            //return everything to model
            model.RacesViewModel = rvm;
            return model;
        }

        /// <summary>
        /// Initial view model of all races (edit view - httpget)
        /// </summary>
        /// <param name="ultimate"></param>
        /// <returns>UltimateViewModel</returns>
        private UltimateViewModel GetRacesInitialModel(UltimateViewModel ultimate, int? thisId)
        {
            //setup properties
            var rvm = ultimate.RacesViewModel;
            var postedRaces = rvm.PostedRaces;

            //setup view model
            rvm.AvailableRaces = db.Races.ToList();

            //return everything to model
            ultimate.RacesViewModel = rvm;
            return ultimate;
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