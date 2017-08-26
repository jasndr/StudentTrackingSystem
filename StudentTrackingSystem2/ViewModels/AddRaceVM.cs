using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentTrackingSystem2.Models;

namespace StudentTrackingSystem2.ViewModels
{
    public class AddRaceVM : Graduate_Races
    {

        public List<CheckBoxListItem> Races { get; set; }

        public AddRaceVM()
        {
            Races = new List<CheckBoxListItem>();
        }

    }
}