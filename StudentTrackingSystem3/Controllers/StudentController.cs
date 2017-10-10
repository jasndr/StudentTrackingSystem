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
using PagedList;
using Microsoft.Reporting.WebForms;
using StudentTrackingSystem3.Reports;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentTrackingSystem3.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Student
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            //if sortOrder is empty, then (sort by student num asc), otherwise (sort by student num desc)
            ViewBag.StudentID_SortParm = String.IsNullOrEmpty(sortOrder) ? "studentID_desc" : "";

            //if sortOrder = FirstName, then (sort z->a), otherwise (sort a->z, should be default)
            ViewBag.FirstName_SortParm = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";

            //if sortOrder = LastName, then (sort z->a), otherwise (sort a->z, should be default)
            ViewBag.LastName_SortParm = sortOrder == "LastName" ? "LastName_desc" : "LastName";

            //if sortOrder = SchoolEmail = then (sort z->a), otherwise (sort a->z, should be default)
            ViewBag.SchoolEmail_SortParm = sortOrder == "SchoolEmail" ? "SchoolEmail_desc" : "SchoolEmail";  

            //if sortOrder = ConcentrationsId then (sort by concentrationsid desc), otherwise (sort by concentrationsid asc, should be default)
            ViewBag.ConcentrationsId_SortParm = sortOrder == "ConcentrationsId" ? "ConcentrationsId_desc" : "ConcentrationsId";

            //if sortOrder = TracksId then (sort by Tracksid desc), otherwise (sort by Tracksid, should be default)
            ViewBag.TracksId_SortParm = sortOrder == "TracksId" ? "TracksId_desc" : "TracksId";

            //if sortOrder = DegreeStartSem then (sort by date new->old), otherwise (sort by date old-new, should be default)
            ViewBag.DegreeStart_SortParm = sortOrder == "DegreeStart" ? "DegreeStart_desc" : "DegreeStart";
            
           
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in db.Students
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                            || s.FirstName.Contains(searchString)
                                            || s.SchoolEmail.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "studentID_desc":
                    students = students.OrderByDescending(s => s.StudentNumber);
                    break;
                case "FirstName":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                case "FirstName_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    students = students.OrderBy(s => s.LastName);
                    break;
                case "LastName_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "SchoolEmail":
                    students = students.OrderBy(s => s.SchoolEmail);
                    break;
                case "SchoolEmail_desc":
                    students = students.OrderByDescending(s => s.SchoolEmail);
                    break;
                case "ConcentrationsId":
                    students = students.OrderBy(s => s.ConcentrationsId);
                    break;
                case "ConcentrationsId_desc":
                    students = students.OrderByDescending(s => s.ConcentrationsId);
                    break;
                case "TracksId":
                    students = students.OrderBy(s => s.TracksId);
                    break;
                case "TracksId_desc":
                    students = students.OrderByDescending(s => s.TracksId);
                    break;
                case "DegreeStart":
                    students = students.OrderBy(s => s.DegreeStartYear).ThenBy(s=>s.DegreeStartSems.DisplayOrder);
                    break;
                case "DegreeStart_desc":
                    students = students.OrderByDescending(s => s.DegreeStartYear).ThenByDescending(s => s.DegreeStartSems.DisplayOrder);
                    break;
                default:
                    students = students.OrderBy(s => s.StudentNumber);
                    break;
  
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        MyDataSet ds = new MyDataSet();
        public ActionResult Report_StudentBackground()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            var connectionString = ConfigurationManager.ConnectionStrings["SchoolContext"].ConnectionString;

            //private SchoolContext db = new SchoolContext();
            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT DISTINCT s.StudentNumber      ,s.FirstName	  ,s.MiddleName	  ,s.LastName	  ,s.SchoolEmail	  ,s.OtherEmail	  ,s.Phone	  ,gen.Name [Gender]	  ,STUFF((	    SELECT ', ' + r2.Name 	    FROM G_Races r2 		INNER JOIN G_PersonRaces pr2 ON pr2.RaceID = r2.Id		INNER JOIN G_Student s2 ON pr2.StudentID = s2.Id		WHERE  s2.Id = s.Id		FOR XML PATH ('')), 1, 1, '') [RaceEthnicity]	  ,deg.Name [DegreeProgram]	  ,tra.Name [Track]	  ,pla.Name [Plan]	  ,CONVERT(varchar(10), cast(s.DegreeStart as date), 101) [DegreeStart]	  ,CONVERT(varchar(10), cast(s.DegreeEnd as date), 101) [DegreeEnd]FROM G_Student sINNER JOIN G_PersonRaces pr ON s.Id = pr.StudentID INNER JOIN G_Races r ON pr.RaceID = r.Id INNER JOIN G_CommonFields gen ON s.GendersId = gen.ID INNER JOIN G_CommonFields deg ON s.DegreeProgramsId = deg.ID INNER JOIN G_CommonFields tra ON s.ConcentrationsId = tra.ID INNER JOIN G_CommonFields pla ON s.TracksId = pla.ID", conx);
            adp.Fill(ds, ds.DataTable1.TableName);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\Background-Rpt.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));

            ViewBag.ReportViewer = reportViewer;

            return View();
    }

        // [Information page to display them a brief page before proceeding to subsections]
        // GET : Student/Info/5
        public ActionResult Info(int? id)
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
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");
            ViewBag.PlansIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Plan"), "Id", "Name");
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");

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

                    return RedirectToAction("Edit", "Student", new { id = ultimate.G_Student.Id });
                    //return RedirectToAction("Index");
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
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");
            ViewBag.PlansIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Plan"), "Id", "Name");
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");


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
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");
            ViewBag.PlansIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Plan"), "Id", "Name");
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");

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

                    return RedirectToAction("Edit", "Student", new { id = ultimate.G_Student.Id });
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
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");

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