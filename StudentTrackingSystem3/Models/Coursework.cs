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
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int PassFailID { get; set; }
        

      
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual CommonFields PassFail { get; set; }
      


    }
}