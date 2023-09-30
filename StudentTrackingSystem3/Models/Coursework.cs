﻿using System;
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
        public int StudentDegreeProgramID { get; set; }
        public int CourseID { get; set; }
        public int PassFailID { get; set; }
        

      
        public virtual StudentDegreeProgram StudentDegreeProgram { get; set; }
        public virtual Course Course { get; set; }
        public virtual CommonFields PassFail { get; set; }
      


    }
}