using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem3.Models;

namespace StudentTrackingSystem3.ViewModels
{
    public class ActivityStudentViewModel
    {
        public G_Student Student { get; set; }

        public G_Performance Performance { get; set; }

        public G_Activity Activity { get; set;}
    }

    public class ActivityStudentInumViewModel
    {
        public IEnumerable<ActivityStudentViewModel> activityStudentViewModel { get; set; }
    }

}