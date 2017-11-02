using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_PreviousEmployment
    {
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public string Position { get; set; }
        [Required, Display(Name ="Start Month")]
        public int StartMonthId { get; set; }
        [Required, Range(1000, 9999, ErrorMessage ="Please enter a valid year value."), Display(Name ="Start Year")]
        public int StartYear { get; set; }
        [Required, Display(Name ="End Month")]
        public int EndMonthId { get; set; }
        [Required, Range(1000, 9999, ErrorMessage = "Please enter a valid year value.") , Display(Name ="End Year")]
        public int EndYear { get; set; }  

        public virtual G_Student Student { get; set; }
        public virtual G_CommonFields StartMonth { get; set; }
        public virtual G_CommonFields EndMonth { get; set; }

    }
}