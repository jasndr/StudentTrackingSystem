using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem3.Models;

namespace StudentTrackingSystem3.ViewModels
{
    public class RaceFormViewModel
    {
        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public List<Races> Races { get; set; } 
    }
}