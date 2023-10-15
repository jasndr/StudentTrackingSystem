using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class Manuscript
    {
        public int ID { get; set; }
        public int StudentDegreeProgramID { get; set; }
        
        [Required, Display(Name = "Received Date")]
        public System.DateTime ReceivedDate { get; set; }

        public virtual StudentDegreeProgram StudentDegreeProgram { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
        
}