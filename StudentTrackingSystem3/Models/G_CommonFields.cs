using System;
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
        public virtual ICollection<G_Student> ReturnPlan { get; set; }
        public virtual ICollection<G_Student> ReturnDegreeStartSem { get; set; }
        public virtual ICollection<G_PrevDegree> ReturnDegreeType { get; set; }
        public virtual ICollection<G_Coursework> ReturnSemester { get; set; }
        public virtual ICollection<G_Coursework> ReturnGrade { get; set; }
        public virtual ICollection<G_Performance> ReturnPublicationStat { get; set; }
        public virtual ICollection<G_Performance> ReturnAbstractStat { get; set; }
        public virtual ICollection<G_Performance> ReturnProposalStat { get; set; }
        public virtual ICollection<G_Performance> ReturnTeachingStat { get; set; }
        public virtual ICollection<G_Graduation> ReturnDegreeEndSems { get; set; }
        public virtual ICollection<G_Graduation> ReturnQualifierResults { get; set; }
        public virtual ICollection<G_Graduation> ReturnQualifier2Results { get; set; }
        public virtual ICollection<G_Graduation> ReturnForm2Type { get; set; }
        public virtual ICollection<G_Graduation> ReturnForm2Result { get; set; }
        public virtual ICollection<G_Graduation> ReturnForm3Result { get; set; }
        public virtual ICollection<G_PostGraduation> ReturnCurrentStartMonth { get; set; }
        public virtual ICollection<G_PreviousEmployment> ReturnStartMonth { get; set; }
        public virtual ICollection<G_PreviousEmployment> ReturnEndMonth { get; set; }
        public virtual ICollection<G_Publications> ReturnPubMonth { get; set; }
        public virtual ICollection<G_Grants> ReturnGrantMonth { get; set; }

    }
}