using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    using System.ComponentModel.DataAnnotations;
    public class G_Activity
    {

        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
         
        [Required, Display(Name = "Description")]
        public string ActivitySummaryDesc { get; set; }
        public virtual G_Student Student { get; set; }

    }
}