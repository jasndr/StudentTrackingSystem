﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem3.Models;

namespace StudentTrackingSystem3.ViewModels
{
    public class RacesViewModel
    {
        public IList<G_Races> AvailableRaces { get; set; }
        public IList<G_Races> SelectedRaces { get; set; }
        public PostedRaces PostedRaces { get; set; }
    }

    public class PostedRaces
    {
        public string[] RaceIDs { get; set; }
    }

}