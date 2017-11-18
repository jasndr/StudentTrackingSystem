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
        [Display(Name = "Degree Awarded Semester")]
        public Nullable<int> DegreeEndSemsId { get; set; }
        [Range(1000, 9999), Display(Name = "Degree Awarded Year")]
        public Nullable<int> DegreeEndYear { get; set; }
        [Display(Name = "Result")]
        public Nullable<int> QualifierResultId { get; set; }
        [Display(Name = "Result (Second Attempt)")]
        public Nullable<int> Qualifier2ResultId { get; set; }
        [Display(Name = "Date of Qualification Passed/Failed")]
        public Nullable<System.DateTime> DateOfQualification { get; set; }
        [Display(Name = "Date of Qualification Passed/Failed (Attempt 2)")]
        public Nullable<System.DateTime> DateOfQualification2 { get; set; }
        [Display(Name="Title")]
        public string Form2Title { get; set; }
        [Display(Name ="Date")]
        public Nullable<System.DateTime> Form2Date { get; set; }
        [Display(Name ="Result")]
        public Nullable<int> Form2ResultId { get; set; }
        [Display(Name="Result")]
        public Nullable<int> CompExamResultId { get; set; }
        [Display(Name ="Date of Comprehensive Exam Passed/Failed")]
        public Nullable<System.DateTime> DateOfCompExam { get; set; }
        [Display(Name="Result (Second Attempt)")]
        public Nullable<int> CompExam2ResultId { get; set; }
        [Display(Name="Date of Comprehensive Exam Passed/Failed (Attempt 2)")]
        public Nullable<System.DateTime> DateOfCompExam2 { get; set; }
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
        [Display(Name = "Result")]
        public Nullable<int> FinalExamResultId { get; set; }
        [Display(Name = "Date of Final Exam Passed/Failed")]
        public Nullable<System.DateTime> DateOfFinalExam { get; set; }
        [Display(Name = "Result (Second Attempt)")]
        public Nullable<int> FinalExam2ResultId { get; set; }
        [Display(Name = "Date of Final Exam Passed/Failed (Attempt 2)")]
        public Nullable<System.DateTime> DateOfFinalExam2 { get; set; }


        public virtual G_Student Student { get; set; }
        public virtual G_CommonFields DegreeEndSems { get; set; }
        public virtual G_CommonFields QualifierResult { get; set; }
        public virtual G_CommonFields Qualifier2Result { get; set; }
        public virtual G_CommonFields CompExamResult { get; set; }
        public virtual G_CommonFields CompExam2Result { get; set; }
        public virtual G_CommonFields FinalExamResult { get; set; }
        public virtual G_CommonFields FinalExam2Result { get; set; }
        public virtual G_CommonFields Form2Type { get; set; }
        public virtual G_CommonFields Form2Result { get; set; }
        public virtual G_CommonFields Form3Result { get; set; }


    }
}