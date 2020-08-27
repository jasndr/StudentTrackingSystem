using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class CommonFields
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int DisplayOrder { get; set; }
        public Nullable<decimal> GradePoint { get; set; }

        public virtual ICollection<Student> ReturnGender { get; set; }
        public virtual ICollection<Student> ReturnPrevDeg { get; set; }
        public virtual ICollection<Student> ReturnConcentration { get; set; }
        public virtual ICollection<Student> ReturnTrack { get; set; }
        public virtual ICollection<Student> ReturnPlan { get; set; }
        public virtual ICollection<Student> ReturnDegreeStartSem { get; set; }
        public virtual ICollection<Student> ReturnCitizenshipStat { get; set; }
        public virtual ICollection<PrevDegree> ReturnDegreeType { get; set; }
        public virtual ICollection<Coursework> ReturnSemester { get; set; }
        public virtual ICollection<Coursework> ReturnGrade { get; set; }
        public virtual ICollection<Performance> ReturnPublicationStat { get; set; }
        public virtual ICollection<Performance> ReturnAbstractStat { get; set; }
        public virtual ICollection<Performance> ReturnProposalStat { get; set; }
        public virtual ICollection<Performance> ReturnTeachingStat { get; set; }
        public virtual ICollection<Graduation> ReturnDegreeEndSems { get; set; }
        public virtual ICollection<Graduation> ReturnQualifierResults { get; set; }
        public virtual ICollection<Graduation> ReturnQualifier2Results { get; set; }
        public virtual ICollection<Graduation> ReturnCompExamResults { get; set; }
        public virtual ICollection<Graduation> ReturnQCompExam2Results { get; set; }
        public virtual ICollection<Graduation> ReturnFinalExamResults { get; set; }
        public virtual ICollection<Graduation> ReturnFinalExam2Results { get; set; }
        public virtual ICollection<Graduation> ReturnForm2Type { get; set; }
        public virtual ICollection<Graduation> ReturnForm2Result { get; set; }
        public virtual ICollection<Graduation> ReturnForm3Result { get; set; }
        public virtual ICollection<PostGraduation> ReturnCurrentStartMonth { get; set; }
        public virtual ICollection<PreviousEmployment> ReturnStartMonth { get; set; }
        public virtual ICollection<PreviousEmployment> ReturnEndMonth { get; set; }
        public virtual ICollection<Publications> ReturnPubMonth { get; set; }
        public virtual ICollection<Grants> ReturnGrantMonth { get; set; }
        public virtual ICollection<Honors> ReturnHonorMonth { get; set; }
        

    }
}