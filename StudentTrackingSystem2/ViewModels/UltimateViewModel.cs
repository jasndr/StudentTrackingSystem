using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem2.ViewModels;
using StudentTrackingSystem2.Models;
using System.Web.Mvc;

namespace StudentTrackingSystem2.ViewModels
{
    public class UltimateViewModel
    {
        public Graduate_Student Graduate_Student_Model { get; set; }
        public AddRaceVM AddRace_ViewModel { get; set; }

        ////
        public SelectList GendersList { get; set; }

    }

}