using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentTrackingSystem3.DAL;

namespace StudentTrackingSystem3.Controllers
{
    public class FileController : Controller
    {
        private SchoolContext db = new SchoolContext();
        //
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}