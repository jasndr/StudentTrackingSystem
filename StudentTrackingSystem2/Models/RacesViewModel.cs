using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem2.Models
{
    public class RacesViewModel : Graduate_Student
    {
        public List<Graduate_Races> AvailableRaces { get; set; }
        public List<Graduate_Races> SelectedRaces { get; set; }
        public PostedRaces PostedRaces { get; set; }
    }

    public class PostedRaces
    {
        public string[] RaceIDs { get; set; }
    }

}