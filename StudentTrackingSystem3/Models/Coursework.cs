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

    public class Coursework
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

        public virtual CommonFields Semesters { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual CommonFields Grade { get; set; }


    }
}