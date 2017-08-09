using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentTrackingSystem.Models
{
    public class StudentMetadata
    {
        [Range(10000000,99999999)]
        [Display(Name= "Student ID #")]
        public int StudentNumber { get; set; }

        [StringLength(55)]
        [Display(Name= "First Name")]
        public string FirstName { get; set; }

        [StringLength(55)]
        [Display(Name= "Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(55)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name ="School Email")]
        public string SchoolEmail { get; set; }

        [EmailAddress]
        [Display(Name ="Other Email")]
        public string OtherEmail { get; set; }

        [Phone]
        [Display(Name ="Phone #")]
        public string Phone { get; set; }

        [Display(Name ="Gender")]
        public Nullable<int> GenderId { get; set; }

        [Display(Name ="Degree(s) at Admission")]
        public Nullable<int> DegreeId { get; set; }

        [Display(Name ="Race/Ethnicity")]
        public Nullable<long> RaceEthnicityId { get; set; }

        [StringLength(255)]
        [Display(Name ="Other Race/Ethnicity")]
        public string RaceOther { get; set; }

        [Display(Name = "Degree Program")]
        public Nullable<int> DegreeProgramId { get; set; }

        [Display(Name = "Concentration")]
        public Nullable<int> ConcentrationId { get; set; }

        [Display(Name = "Track")]
        public Nullable<int> TrackId { get; set; }

        [Display(Name ="Degree Program Start")]
        public System.DateTime DegreeStart { get; set; }

        [Display(Name ="Degree Program End")]
        public System.DateTime DegreeEnd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Coursework> Graduate_Coursework { get; set; }
        [Display(Name ="Concentration")]
        public virtual Graduate_CommonFields Graduate_CommonFields { get; set; }
        [Display(Name ="Degree Program")]
        public virtual Graduate_CommonFields Graduate_CommonFields1 { get; set; }
        [Display(Name ="Gender")]
        public virtual Graduate_CommonFields Graduate_CommonFields2 { get; set; }
        [Display(Name ="Track")]
        public virtual Graduate_CommonFields Graduate_CommonFields3 { get; set; }
        [Display(Name ="Degree(s) at admission")]
        public virtual Graduate_PrevDegree Graduate_PrevDegree { get; set; }


    }
}