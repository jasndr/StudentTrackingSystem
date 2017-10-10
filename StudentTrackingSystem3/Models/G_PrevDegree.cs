using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_PrevDegree
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int DegreeTypesID { get; set; }
        public string Title { get; set; }
        public decimal CumulativeGPA { get; set; }
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public string SecondMajor { get; set; }
        public string Minor { get; set; }
        public System.DateTime DateOfAward { get; set; }

        public G_Student Student { get; set; }
        public virtual G_CommonFields DegreeTypes { get; set; }

    }
}