using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem3.Models;

namespace StudentTrackingSystem3.ViewModels
{
    public class RacesViewModel
    {
        public IEnumerable<Races> AvailableRaces { get; set; }
        public IEnumerable<Races> SelectedRaces { get; set; }
        public PostedRaces PostedRaces { get; set; }
    }
    public class PostedRaces
    {
        public string[] RaceIDs { get; set; }
    }

}