using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_PrevDegree
    {
        public int Id { get; set; }
        public int DegreeTypeId { get; set; }
        public string Title { get; set; }
        public decimal GPA { get; set; }
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public string SecondMajor { get; set; }
        public string Minor { get; set; }
        public System.DateTime DateOfAward { get; set; }

        public G_Student Student { get; set; }
        public G_CommonFields DegreeType { get; set; }

    }
}