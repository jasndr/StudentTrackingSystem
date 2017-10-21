using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Performance
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        [Required, Display(Name ="Category")]
        public int CategoryID { get; set; }
        [Required, Display(Name = "Information")]
        public string CategoryInfo { get; set; }
        [Display(Name ="Publication Status")]
        public Nullable<int> PublicationStatID { get; set; }
        [Display(Name = "Abstract Status")]
        public Nullable<int> AbstractStatID { get; set; }
        [Display(Name = "Proposal Status")]
        public Nullable<int> ProposalStatID { get; set; }
        [Display(Name = "Teaching Status")]
        public Nullable<int> TeachingStatID { get; set; }

        public virtual G_Student Student { get; set; }
        public virtual G_CommonFields Category { get; set; }
        public virtual G_CommonFields PublicationStats { get; set; }
        public virtual G_CommonFields AbstractStats { get; set; }
        public virtual G_CommonFields ProposalStats { get; set; }
        public virtual G_CommonFields TeachingStats { get; set; }
    }
}