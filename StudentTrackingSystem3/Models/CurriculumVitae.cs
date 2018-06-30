using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class CurriculumVitae
    {
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required, Display(Name = "Received Date")]
        public System.DateTime ReceivedDate {get;set;}
        public virtual Student Student { get; set; }
        public virtual ICollection<File> Files { get; set; }


    }
}