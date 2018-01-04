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
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }
        [Required, Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required, EmailAddress, Display(Name = "School Email")]
        public string SchoolEmail { get; set; }
        [Required, EmailAddress, Display(Name = "Other Email")]
        public string OtherEmail { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required, Display(Name="Gender")]//[ForeignKey()]
        public int GendersId { get; set; }
        [Display(Name ="Race Other")]
        public string RaceOther { get; set; }
        [Required, Display(Name ="Degree Program")]//[ForeignKey()]
        public int DegreeProgramsId { get; set; }
        [Required, Display(Name ="Track")]//[ForeignKey()]
        public int TracksId { get; set; }
        [Required, Display(Name ="Plan")]//[ForeignKey()]
        public int PlansId { get; set; }
        [Required, Display(Name ="Degree Program Start Semester")]//[ForeignKey()]
        public int DegreeStartSemsId { get; set; }
        [Required, Range(1000, 9999), Display(Name ="Degree Program Start Year")]
        public int DegreeStartYear { get; set; }

        public virtual G_CommonFields Genders { get; set; }
        public virtual G_CommonFields DegreePrograms { get; set; }
        public virtual G_CommonFields Tracks { get; set; }
        public virtual G_CommonFields Plans { get; set; }
        public virtual G_CommonFields DegreeStartSems { get; set; }
        

        [Display(Name = "Race/Ethnicity")]
        public virtual ICollection<G_PersonRaces> PersonRaces { get; set; }
        public virtual ICollection<G_Coursework> Coursework { get; set; }
        [Display(Name = "Degree(s) at Admission")]
        public virtual ICollection<G_PrevDegree> PreviousDegrees { get; set; }
        public virtual ICollection<G_Performance> Performances { get; set; }
        public virtual ICollection<G_Activity> Activity { get; set; }
        public virtual ICollection<G_Graduation> Graduation { get; set; }
        public virtual ICollection<G_CommitteeMember> CommitteeMembers { get; set; }
        public virtual ICollection<G_PostGraduation> PostGraduation { get; set; }
        public virtual ICollection<G_CurriculumVitae> CurriculumVitae { get; set; }
        public virtual ICollection<G_PreviousEmployment> PreviousEmployment { get; set; }
        public virtual ICollection<G_Publications> Publications { get; set; }
        public virtual ICollection<G_Grants> Grants { get; set; }
        public virtual ICollection<G_Honors> Honors { get; set; }
        public virtual ICollection<G_Manuscript> Manuscripts { get; set; }
        //public virtual ICollection<G_File> Files { get; set; }

    }
}