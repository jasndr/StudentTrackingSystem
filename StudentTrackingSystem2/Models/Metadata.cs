using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentTrackingSystem2.Models
{
    public class StudentMetadata
    {
        public int Id { get; set; }

        [Range(10000000, 99999999)][Display(Name ="Student ID #")]
        public int StudentNumber { get; set; }

        [StringLength(55)][Display(Name ="First Name")]
        public string FirstName { get; set; }

        [StringLength(55)][Display(Name ="Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(55)][Display(Name ="Last Name")]
        public string LastName { get; set; }

        [EmailAddress][Display(Name ="School Email")]
        public string SchoolEmail { get; set; }

        [EmailAddress][Display(Name ="Other Email")]
        public string OtherEmail { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Display(Name ="Gender")]
        public Nullable<int> GenderId { get; set; }

        [Display(Name ="Degree")]
        public Nullable<int> DegreeId { get; set; }

        [Display(Name ="Race/Ethnicity")]
        public Nullable<int> RaceEthnicityId { get; set; }

        [Display(Name ="Race/Ethnicity Other")]
        public string RaceOther { get; set; }

        [Display(Name ="Degree Program")]
        public Nullable<int> DegreeProgramId { get; set; }

        [Display(Name ="Concentration")]
        public Nullable<int> ConcentrationId { get; set; }

        [Display(Name ="Track")]
        public Nullable<int> TrackId { get; set; }

        [Display(Name ="Degree Program Start")]
        public System.DateTime DegreeStart { get; set; }

        [Display(Name ="Degree Program End")]
        public System.DateTime DegreeEnd { get; set; }

        public virtual Graduate_CommonFields Graduate_CommonFields { get; set; }
        public virtual Graduate_CommonFields Graduate_CommonFields1 { get; set; }
        public virtual Graduate_CommonFields Graduate_CommonFields2 { get; set; }
        public virtual Graduate_CommonFields Graduate_CommonFields3 { get; set; }
        public virtual Graduate_CommonFields Graduate_CommonFields4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Coursework> Graduate_Coursework { get; set; }
        public virtual Graduate_PrevDegree Graduate_PrevDegree { get; set; }
    }

    public class CourseworkMetaData
    {
        public int Id { get; set; }

        [Display(Name ="Student ID Number")]
        public int StudentID { get; set; }

        [Display(Name ="Semester")]
        public int SemesterID { get; set; }

        public int Year { get; set; }

        [Display(Name ="Course")]
        public int CourseID { get; set; }

        public virtual Graduate_CommonFields Graduate_CommonFields { get; set; }
        public virtual Graduate_Course Graduate_Course { get; set; }
        public virtual Graduate_Student Graduate_Student { get; set; }
    }

}