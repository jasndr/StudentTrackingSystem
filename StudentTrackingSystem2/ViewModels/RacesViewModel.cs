using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem2.Models;

namespace StudentTrackingSystem2.ViewModels
{
    public class RacesViewModel : Graduate_Races
    {
        public IList<Graduate_Races> AvailableRaces { get; set; }
        public IList<Graduate_Races> SelectedRaces { get; set; }
        public PostedRaces PostedRaces { get; set; }
    }

    public class PostedRaces
    {
        public string[] RaceIDs { get; set; }
    }

  

}