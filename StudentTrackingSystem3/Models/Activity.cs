using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    
    public class Activity
    {
        public int ID { get; set; }
        [Required]
        public int StudentDegreeProgramID { get; set; }
         
        [Required, Display(Name = "Description")]
        public string ActivitySummaryDesc { get; set; }

        public virtual StudentDegreeProgram StudentDegreeProgram { get; set; }
        public virtual ICollection<File> Files { get; set; }

    }
}