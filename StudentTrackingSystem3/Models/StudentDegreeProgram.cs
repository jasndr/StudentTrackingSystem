using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class StudentDegreeProgram
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }


        [Required, Display(Name = "Program")]//[ForeignKey()]
        public int DegreeProgramsTypeId { get; set; }
        [Display(Name = "Track")]//[ForeignKey()]
        public Nullable<int> TracksId { get; set; }
        [Display(Name = "Plan")]//[ForeignKey()]
        public Nullable<int> PlansId { get; set; }
        [Required, Display(Name = "Program Start Semester")]//[ForeignKey()]
        public int DegreeStartSemsId { get; set; }
        [Required, Range(1000, 9999), Display(Name = "Program Start Year")]
        public int DegreeStartYear { get; set; }

        public virtual CommonFields DegreePrograms { get; set; }
        public virtual CommonFields Tracks { get; set; }
        public virtual CommonFields Plans { get; set; }
        public virtual CommonFields DegreeStartSems { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<Coursework> Coursework { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<Graduation> Graduation { get; set; }
        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; }
        public virtual ICollection<Manuscript> Manuscripts { get; set; }

        //public virtual ICollection<G_File> Files { get; set; }

    }
}