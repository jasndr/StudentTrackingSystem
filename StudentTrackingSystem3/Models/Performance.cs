using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class Performance
    {
        public int ID { get; set; }
        public int StudentDegreeProgramID { get; set; }
        [Required, Display(Name ="Category")]
        public int CategoryID { get; set; }
        [Required, Display(Name = "Information")]
        public string CategoryInfo { get; set; }
        [Display(Name ="Publication Status")]
        public Nullable<int> PublicationStatsID { get; set; }
        [Display(Name = "Abstract Status")]
        public Nullable<int> AbstractStatsID { get; set; }
        [Display(Name = "Proposal Status")]
        public Nullable<int> ProposalStatsID { get; set; }
        [Display(Name = "Teaching Status")]
        public Nullable<int> TeachingStatsID { get; set; }

        public virtual StudentDegreeProgram StudentDegreeProgram { get; set; }
        public virtual CommonFields Category { get; set; }
        public virtual CommonFields PublicationStats { get; set; }
        public virtual CommonFields AbstractStats { get; set; }
        public virtual CommonFields ProposalStats { get; set; }
        public virtual CommonFields TeachingStats { get; set; }
    }
}