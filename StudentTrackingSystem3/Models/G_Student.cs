using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Student
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(10000000, 99999999), Display(Name ="Student ID #")]
        public int StudentNumber { get; set; }
        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name ="Middle Name")]
        public string MiddleName { get; set; }
        [Required, Display(Name ="Last Name")]
        public string LastName { get; set; }
        [EmailAddress, Display(Name = "School Email")]
        public string SchoolEmail { get; set; }
        [EmailAddress, Display(Name = "Other Email")]
        public string OtherEmail { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Display(Name="Gender")]//[ForeignKey()]
        public Nullable<int> GendersId { get; set; }
        [Display(Name ="Race Other")]
        public string RaceOther { get; set; }
        [Display(Name ="Degree Program")]//[ForeignKey()]
        public Nullable<int> DegreeProgramsId { get; set; }
        [Display(Name ="Concentration")]//[ForeignKey()]
        public Nullable<int> ConcentrationsId { get; set; }
        [Display(Name ="Track")]//[ForeignKey()]
        public Nullable<int> TracksId { get; set; }
        [Display(Name ="Degree Program Start")]
        public System.DateTime DegreeStart { get; set; }
        [Display(Name ="Degree Program End")]
        public System.DateTime DegreeEnd { get; set; }

        public virtual G_CommonFields Genders { get; set; }
        public virtual G_CommonFields DegreePrograms { get; set; }
        public virtual G_CommonFields Concentrations { get; set; }
        public virtual G_CommonFields Tracks { get; set; }

        public virtual ICollection<G_CommonFields> Races { get; set; }
        public virtual ICollection<G_Coursework> Coursework { get; set; }
        public virtual ICollection<G_PrevDegree> PreviousDegrees { get; set; }
        
    }
}