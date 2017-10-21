using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    //public enum Grade
    //{
    //    A, B, C, D, F
    //}

    public class G_Coursework
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        [Required]
        public int? SemestersID { get; set; }
        [Required, Range(1000,9999)]
        public int Year { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int GradeID { get; set; }
        public string Comments { get; set; }

        public virtual G_CommonFields Semesters { get; set; }
        public virtual G_Student Student { get; set; }
        public virtual G_Course Course { get; set; }
        public virtual G_CommonFields Grade { get; set; }


    }
}