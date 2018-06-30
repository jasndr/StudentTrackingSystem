using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem3.Models;

namespace StudentTrackingSystem3.ViewModels
{
    public class UltimateViewModel
    {
        public Student Student { get; set; }

        public RacesViewModel RacesViewModel { get; set;}
    }
        
}