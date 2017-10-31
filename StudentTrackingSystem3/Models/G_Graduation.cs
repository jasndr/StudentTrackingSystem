using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Graduation
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        [Display(Name ="Expected Graduation Semester")]
        public Nullable<int> DegreeEndSemsId { get; set; }
        [Range(1000, 9999), Display(Name = "Year")]
        public Nullable<int> DegreeEndYear { get; set; }
        [Display(Name ="Result")]
        public Nullable<int> QualifierResultId { get; set; }
        [Display(Name ="Result (Second Attempt)")]
        public Nullable<int> Qualifier2ResultId { get; set; }
        [Display(Name = "Date of Qualification Passed")]
        public Nullable<System.DateTime> DateOfQualification { get; set; }
        [Display(Name ="Type")]
        public Nullable<int> Form2TypeId { get; set; }
        [Display(Name="Title")]
        public string Form2Title { get; set; }
        [Display(Name ="Date")]
        public Nullable<System.DateTime> Form2Date { get; set; }
        [Display(Name ="Result")]
        public Nullable<int> Form2ResultId { get; set; }
        [Display(Name ="Type")]
        public Nullable<int> CommitteeTypeID { get; set; }
        [Display(Name ="Name")]
        public string AdvisorName { get; set; }
        [Display(Name="Email"), EmailAddress]
        public string AdvisorEmail { get; set; }
        [Display(Name ="Department")]
        public string AdvisorDepartment { get; set; }
        [Display(Name="University")]
        public string AdvisorUniversity { get; set; }
        [Display(Name ="Presentation Title")]
        public string Form3Title { get; set; }
        [Display(Name ="Date")]
        public Nullable<System.DateTime> Form3Date { get; set; }
        [Display(Name ="Result")]
        public Nullable<int> Form3ResultId { get; set; }
        

        public virtual G_Student Student { get; set; }
        public virtual G_CommonFields DegreeEndSems { get; set; }
        public virtual G_CommonFields QualifierResult { get; set; }
        public virtual G_CommonFields Qualifier2Result { get; set; }
        public virtual G_CommonFields Form2Type { get; set; }
        public virtual G_CommonFields Form2Result { get; set; }
        public virtual G_CommonFields Form3Result { get; set; }


    }
}