using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class Student
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

        [Range(0, 130), Display(Name = "Age at Enrollment")]
        public int Age { get; set; }

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
        [Display(Name = "Other Asian")]
        public string RaceAsianOther { get; set; }
        [Display(Name ="Other Pacific Islander")]
        public string RacePacIsleOther { get; set; }

        [Required, Display(Name ="Program")]//[ForeignKey()]
        public int DegreeProgramsId { get; set; }
        [Display(Name ="Track")]//[ForeignKey()]
        public Nullable<int> TracksId { get; set; }
        [Display(Name ="Plan")]//[ForeignKey()]
        public Nullable<int> PlansId { get; set; }
        [Required, Display(Name ="Program Start Semester")]//[ForeignKey()]
        public int DegreeStartSemsId { get; set; }
        [Required, Range(1000, 9999), Display(Name ="Program Start Year")]
        public int DegreeStartYear { get; set; }
        [Required, Display(Name ="Citizenship Status")]//[ForeignKey()]
        public int CitizenshipStatsId { get; set; }
        [Required, Display(Name ="Current Status of Employment")]//[ForeignKey()]
        public int EmploymentStatsId { get; set; }
        public string EmploymentStatsOther { get; set; }
        [Display(Name ="Interim Academic Advisor")]
        public Nullable<int> InterimAdvisorsId { get; set; }
        [Display(Name = "Permanent Academic Advisor")]
        public Nullable<int> PermanentAdvisorsId { get; set; }
        [Display(Name = "Other Permanent Academic Advisor")]
        public string PermanentAdvisorOther { get; set; }


        public virtual CommonFields Genders { get; set; }
        public virtual CommonFields DegreePrograms { get; set; }
        public virtual CommonFields Tracks { get; set; }
        public virtual CommonFields Plans { get; set; }
        public virtual CommonFields DegreeStartSems { get; set; }
        public virtual CommonFields CitizenshipStats { get; set; }
        public virtual CommonFields EmploymentStats { get; set; }
        public virtual CommonFields InterimAdvisors { get; set; }
        public virtual CommonFields PermanentAdvisors { get; set; }


        

        [Display(Name = "Race/Ethnicity")]
        public virtual ICollection<PersonRaces> PersonRaces { get; set; }
        public virtual ICollection<Coursework> Coursework { get; set; }
        [Display(Name = "Degree(s) at Admission")]
        public virtual ICollection<PrevDegree> PreviousDegrees { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<Graduation> Graduation { get; set; }
        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; }
        public virtual ICollection<PostGraduation> PostGraduation { get; set; }
        public virtual ICollection<CurriculumVitae> CurriculumVitae { get; set; }
        public virtual ICollection<PreviousEmployment> PreviousEmployment { get; set; }
        public virtual ICollection<Publications> Publications { get; set; }
        public virtual ICollection<Grants> Grants { get; set; }
        public virtual ICollection<Honors> Honors { get; set; }
        public virtual ICollection<Manuscript> Manuscripts { get; set; }

        //public virtual ICollection<G_File> Files { get; set; }

    }
}