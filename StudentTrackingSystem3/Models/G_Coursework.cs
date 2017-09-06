using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class G_Coursework
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SemestersID { get; set; }
        public int Year { get; set; }
        public int CourseID { get; set; }
        public Grade? Grade { get; set; }

        public virtual G_CommonFields Semesters { get; set; }
        public virtual G_Student Student { get; set; }
        public virtual G_Course Course { get; set; }


    }
}