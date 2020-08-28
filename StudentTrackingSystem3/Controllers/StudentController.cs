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
using StudentTrackingSystem3.Reports.DataSet1TableAdapters;

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
            //if sortOrder = DegreeProgramsId then (sort by degreeprogramsid desc), otherwise (sort by degreeprogramsid asc, should be default)
            ViewBag.DegreeProgramsId_SortParm = sortOrder == "DegreeProgramsId" ? "DegreeProgramsId_desc" : "DegreeProgramsId";
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
                           where s.Graduation.FirstOrDefault() == null
                                 || (s.Graduation.FirstOrDefault() != null && s.Graduation.FirstOrDefault().DegreeEndYear == null)
                                 || (s.Graduation.FirstOrDefault() != null && s.Graduation.FirstOrDefault().DegreeEndYear != null
                                     && s.Graduation.FirstOrDefault().DegreeEndYear > DateTime.Now.Year)
                                 || (s.Graduation.FirstOrDefault() != null
                                      && s.Graduation.FirstOrDefault().DegreeEndYear != null && s.Graduation.FirstOrDefault().DegreeEndSems != null
                                      && (s.Graduation.FirstOrDefault().DegreeEndYear > DateTime.Now.Year
                                           || s.Graduation.FirstOrDefault().DegreeEndYear == DateTime.Now.Year &&
                                          s.Graduation.FirstOrDefault().DegreeEndSemsId * 4 > DateTime.Now.Month))
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
                case "DegreeProgramsId":
                    students = students.OrderBy(s => s.DegreeProgramsId);
                    break;
                case "DegreeProgramsId_desc":
                    students = students.OrderByDescending(s => s.DegreeProgramsId);
                    break;
                case "TracksId":
                    students = students.OrderBy(s => s.TracksId);
                    break;
                case "TracksId_desc":
                    students = students.OrderByDescending(s => s.TracksId);
                    break;
                case "DegreeStart":
                    students = students.OrderBy(s => s.DegreeStartYear).ThenBy(s => s.DegreeStartSems.DisplayOrder);
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

        // GET: Former (Students)
        public ActionResult Former(string sortOrder, string currentFilter, string searchString, int? page)
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
            //if sortOrder = DegreeProgramsId then (sort by degreeprogramsid desc), otherwise (sort by degreeprogramsid asc, should be default)
            ViewBag.DegreeProgramsId_SortParm = sortOrder == "DegreeProgramsId" ? "DegreeProgramsId_desc" : "DegreeProgramsId";
            //if sortOrder = TracksId then (sort by Tracksid desc), otherwise (sort by Tracksid, should be default)
            ViewBag.TracksId_SortParm = sortOrder == "TracksId" ? "TracksId_desc" : "TracksId";
            //if sortOrder = DegreeStartSem then (sort by date new->old), otherwise (sort by date old-new, should be default)
            ViewBag.DegreeStart_SortParm = sortOrder == "DegreeStart" ? "DegreeStart_desc" : "DegreeStart";
            //if sortOrder = DegreeStartEnd then (sort by date new->old), otherwise (sort by date old-new, should be default)
            ViewBag.DegreeEnd_SportParm = sortOrder == "DegreeEnd" ? "DegreeEnd_desc" : "DegreeEnd";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var formerStudents = from s in db.Students
                                 where s.Graduation.FirstOrDefault() != null
                                    && s.Graduation.FirstOrDefault().DegreeEndSems != null
                                    && s.Graduation.FirstOrDefault().DegreeEndYear != null
                                    && (s.Graduation.FirstOrDefault().DegreeEndYear < DateTime.Now.Year
                                       || s.Graduation.FirstOrDefault().DegreeEndYear == DateTime.Now.Year &&
                                          s.Graduation.FirstOrDefault().DegreeEndSemsId * 4 < DateTime.Now.Month)
                                 select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                formerStudents = formerStudents.Where(s => s.LastName.Contains(searchString)
                                            || s.FirstName.Contains(searchString)
                                            || s.SchoolEmail.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "studentID_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.StudentNumber);
                    break;
                case "FirstName":
                    formerStudents = formerStudents.OrderBy(s => s.FirstName);
                    break;
                case "FirstName_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    formerStudents = formerStudents.OrderBy(s => s.LastName);
                    break;
                case "LastName_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.LastName);
                    break;
                case "SchoolEmail":
                    formerStudents = formerStudents.OrderBy(s => s.SchoolEmail);
                    break;
                case "SchoolEmail_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.SchoolEmail);
                    break;
                case "DegreeProgramsId":
                    formerStudents = formerStudents.OrderBy(s => s.DegreeProgramsId);
                    break;
                case "DegreeProgramsId_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.DegreeProgramsId);
                    break;
                case "TracksId":
                    formerStudents = formerStudents.OrderBy(s => s.TracksId);
                    break;
                case "TracksId_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.TracksId);
                    break;
                case "DegreeStart":
                    formerStudents = formerStudents.OrderBy(s => s.DegreeStartYear).ThenBy(s => s.DegreeStartSems.DisplayOrder);
                    break;
                case "DegreeStart_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.DegreeStartYear).ThenByDescending(s => s.DegreeStartSems.DisplayOrder);
                    break;
                case "DegreeEnd":
                    formerStudents = formerStudents.OrderBy(s => s.Graduation.FirstOrDefault().DegreeEndYear).ThenBy(s => s.Graduation.FirstOrDefault().DegreeEndSems.DisplayOrder);
                    break;
                case "DegreeEnd_desc":
                    formerStudents = formerStudents.OrderByDescending(s => s.Graduation.FirstOrDefault().DegreeEndYear).ThenByDescending(s => s.Graduation.FirstOrDefault().DegreeEndSems.DisplayOrder);
                    break;
                default:
                    formerStudents = formerStudents.OrderBy(s => s.StudentNumber);
                    break;

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(formerStudents.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Report()
        {
            var students =
                db.Students.AsEnumerable().Select(s => new
                {
                    //ID = s.Id,
                    FullName = string.Format("{0} {1}", s.FirstName, s.LastName)
                }).OrderBy(s => s.FullName).ToList();
            ViewBag.ListOfStudents = new SelectList(students, "FullName", "FullName");
            ViewBag.ReportViewer = new ReportViewer();

            return View();
        }

        [HttpPost]
        public ActionResult Report(string ReportType, string ListOfStudents, string CurrentFormer, string FromDateParam, string ToDateParam)
        {

            DataSet1 ds = new DataSet1();

            ReportParameter[] paramsArray;

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            switch (ReportType)
            {
                case "Background":

                    paramsArray = new ReportParameter[4];
                    paramsArray[0] = new ReportParameter("FromDateParam", FromDateParam.ToString());
                    paramsArray[1] = new ReportParameter("ToDateParam", ToDateParam.ToString());
                    paramsArray[2] = new ReportParameter("Student", ListOfStudents.ToString());
                    paramsArray[3] = new ReportParameter("CurrentFormer", CurrentFormer.ToString());


                    BackgroundTableAdapter bta = new BackgroundTableAdapter();
                    bta.Fill(ds.Background, FromDateParam, ToDateParam, ListOfStudents, CurrentFormer);

                    reportViewer.LocalReport.DataSources.Clear();

                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\Rpt1-Background.rdlc";
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Background", ds.Tables[0]));

                    reportViewer.LocalReport.SetParameters(paramsArray);

                    reportViewer.LocalReport.Refresh();

                    break;
                case "Coursework":

                    paramsArray = new ReportParameter[1];
                    paramsArray[0] = new ReportParameter("Student", ListOfStudents.ToString());


                    CourseworkTableAdapter cta = new CourseworkTableAdapter();
                    cta.Fill(ds.Coursework, ListOfStudents);

                    reportViewer.LocalReport.DataSources.Clear();

                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\Rpt2-Coursework.rdlc";
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Coursework", ds.Tables[1]));

                    reportViewer.LocalReport.SetParameters(paramsArray);

                    reportViewer.LocalReport.Refresh();

                    break;
                case "Performance":

                    paramsArray = new ReportParameter[1];
                    paramsArray[0] = new ReportParameter("Student", ListOfStudents.ToString());


                    PerformanceTableAdapter pta = new PerformanceTableAdapter();
                    pta.Fill(ds.Performance, ListOfStudents);

                    reportViewer.LocalReport.DataSources.Clear();

                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\Rpt3-Performance.rdlc";
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Performance", ds.Tables[2]));

                    reportViewer.LocalReport.SetParameters(paramsArray);

                    reportViewer.LocalReport.Refresh();

                    break;
                case "Requirements":

                    paramsArray = new ReportParameter[4];
                    paramsArray[0] = new ReportParameter("Student", ListOfStudents.ToString());
                    paramsArray[1] = new ReportParameter("CurrentFormer", CurrentFormer.ToString());
                    paramsArray[2] = new ReportParameter("FromDateParam", FromDateParam.ToString());
                    paramsArray[3] = new ReportParameter("ToDateParam", ToDateParam.ToString());
                    

                    RequirementsTableAdapter rta = new RequirementsTableAdapter();
                    rta.Fill(ds.Requirements, FromDateParam, ToDateParam, ListOfStudents, CurrentFormer);

                    reportViewer.LocalReport.DataSources.Clear();

                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\Rpt4-Requirements.rdlc";
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Requirements", ds.Tables[3]));

                    reportViewer.LocalReport.SetParameters(paramsArray);

                    reportViewer.LocalReport.Refresh();

                    break;
                case "PostGraduation":

                    paramsArray = new ReportParameter[1];
                    paramsArray[0] = new ReportParameter("Student", ListOfStudents.ToString());

                    PostgraduationTableAdapter pgta = new PostgraduationTableAdapter();
                    pgta.Fill(ds.Postgraduation, ListOfStudents);

                    reportViewer.LocalReport.DataSources.Clear();

                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\Rpt5-Postgraduation.rdlc";
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Postgraduation", ds.Tables[4]));

                    reportViewer.LocalReport.SetParameters(paramsArray);

                    reportViewer.LocalReport.Refresh();

                    break;

                default:
                    break;
            }

            var students =
                db.Students.AsEnumerable().Select(s => new
                {
                    //ID = s.Id,
                    FullName = string.Format("{0} {1}", s.FirstName, s.LastName)
                }).OrderBy(s => s.FullName).ToList();

            ViewBag.ListOfStudents = new SelectList(students, "FullName", "FullName");

            ViewBag.ReportViewer = reportViewer;

            return View();
        }



        // GET: Student/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            return RedirectToAction("AccessDenied", "Account");

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Student student = db.Students.Find(id);
            //if (student == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(student);
        }


        // GET: Student/Create
        [Authorize(Roles ="Super, Admin, Biostat")]
        public ActionResult Create()
        {
            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");
            ViewBag.PlansIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Plan"), "Id", "Name");
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");
            ViewBag.CitizenshipStatsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "CitizenshipStatus"), "Id", "Name");
            ViewBag.EmploymentStatsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "EmploymentStatus"), "Id", "Name");
            ViewBag.MsctrFacultyIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "MsctrFaculty"), "Id", "Name");

            return View(GetRacesInitialModel());
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Super, Admin, Biostat")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GendersId,RaceOther,DegreeProgramsId,TracksId,DegreeStart,DegreeEnd")] Student student,*/UltimateViewModel ultimate)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //Add recorded student
                    db.Students.Add(ultimate.Student);

                    ultimate.RacesViewModel.AvailableRaces = db.Races.ToList();

                    //For current student, add to personRaceTable, student id number and postedRace number
                    foreach (var item in ultimate.RacesViewModel.PostedRaces.RaceIDs)
                    {
                        var personRace = new PersonRaces();
                        int raceId = Int32.Parse(item);
                        var race = db.Races.Where(s => s.Id == raceId).ToList().Single();
                        personRace.Student = ultimate.Student;
                        personRace.Race = race;
                        personRace.IsSelectedPR = true;
                        db.PersonRaces.Add(personRace);
                        db.SaveChanges();
                        
                    }
                    db.SaveChanges();
                    return RedirectToAction("Edit", "Student", new { id = ultimate.Student.Id });
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
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");
            ViewBag.PlansIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Plan"), "Id", "Name");
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");
            ViewBag.CitizenshipStatsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "CitizenshipStatus"), "Id", "Name");
            ViewBag.MsctrFacultyIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "MsctrFaculty"), "Id", "Name");


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
            rvm.SelectedRaces = new List<Races>();

            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");
            ViewBag.PlansIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Plan"), "Id", "Name");
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");
            ViewBag.CitizenshipStatsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "CitizenshipStatus"), "Id", "Name");
            ViewBag.EmploymentStatsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "EmploymentStatus"), "Id", "Name");
            ViewBag.MsctrFacultyIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "MsctrFaculty"), "Id", "Name");
            ViewBag.Student = student;

            //Initialize selectedRaces
            var racesToPost = new List<Races>();
            foreach (var item in student.PersonRaces.Where(x => x.StudentID == id && x.IsSelectedPR.Equals(true)))
            {
                racesToPost.Add(item.Race);
            }

            //setup ultimate view model
            rvm.SelectedRaces = racesToPost;
            ultimate.RacesViewModel = rvm;
            ultimate.Student = student;

            return View(GetRacesInitialModel(ultimate, id));
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Super")]
        public ActionResult Edit(/*[Bind(Include = "Id,StudentNumber,FirstName,MiddleName,LastName,SchoolEmail,OtherEmail,Phone,GendersId,RaceOther,DegreeProgramsId,TracksId,DegreeStart,DegreeEnd")] Student student*/UltimateViewModel ultimate, PostedRaces postedRaces)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ultimate.Student).State = EntityState.Modified;

                    //Initiate postedRaces;
                    postedRaces = ultimate.RacesViewModel.PostedRaces;

                    //Create current/previously-checked race list
                    var currPRList = db.PersonRaces.Where(s => s.StudentID == ultimate.Student.Id && s.IsSelectedPR.Equals(true)).ToList();
                    var currRaceList = new List<Races>();
                    foreach (var item in currPRList)
                    {
                        currRaceList.Add(item.Race);

                    }
                    //Create new checked race list
                    var newList = new List<Races>();
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
                            var personRace = new PersonRaces();
                            int raceId = nItem.Id;
                            var race = db.Races.Where(s => s.Id == raceId).ToList().Single();
                            personRace.Student = ultimate.Student;
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

                            var prEntity = db.PersonRaces.SingleOrDefault(s => s.StudentID == ultimate.Student.Id && s.RaceID == cItem.Id && s.IsSelectedPR.Equals(true));
                            prEntity.IsSelectedPR = false;

                            db.SaveChanges();
                        }
                    }


                    ultimate.RacesViewModel.SelectedRaces = newList;

                    db.SaveChanges();
                    return RedirectToAction("Edit", "Student", new { id = ultimate.Student.Id });
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex cariable name and ad a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, please see your system administrator.");
            }

            //View Bags for Dropdowns
            ViewBag.GendersIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Gender"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.DegreeProgramsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "DegreeProgram"), "Id", "Name");
            ViewBag.TracksIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Track"), "Id", "Name");
            ViewBag.DegreeStartSemsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "Season"), "Id", "Name");
            ViewBag.CitizenshipStatsIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "CitizenshipStatus"), "Id", "Name");
            ViewBag.MsctrFacultyIdBag = new SelectList(db.CommonFields.Where(o => o.Category == "MsctrFaculty"), "Id", "Name");

            return View(GetRacesModel(ultimate, postedRaces));
        }

        
        // GET: Student/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
            var selectedRaces = new List<Races>();

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

        /// <summary>
        /// Return end month value
        /// </summary>
        /// <param name="semesterVal"></param>
        /// <returns></returns>
        public int endMonthVal(int? semesterVal)
        {
            if (semesterVal == 1)
            {
                return 05;
            }
            else if (semesterVal == 2)
            {
                return 08;
            }
            else if (semesterVal == 3)
            {
                return 12;
            }
            else
            {
                return 01;
            }
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