﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_CommonFields
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int DisplayOrder { get; set; }
        public Nullable<decimal> GradePoint { get; set; }

        public virtual ICollection<G_Student> ReturnGender { get; set; }
        public virtual ICollection<G_Student> ReturnPrevDeg { get; set; }
        public virtual ICollection<G_Student> ReturnConcentration { get; set; }
        public virtual ICollection<G_Student> ReturnTrack { get; set; }
        public virtual ICollection<G_PrevDegree> ReturnDegreeType { get; set; }
        public virtual ICollection<G_Coursework> ReturnSemester { get; set; }
        public virtual ICollection<G_Coursework> ReturnGrade { get; set; }

    }
}