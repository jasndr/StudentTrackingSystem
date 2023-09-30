using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class CommitteeMember
    {
        public int ID { get; set; }
        [Required]
        public int StudentDegreeProgramID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string University { get; set; }


        public virtual StudentDegreeProgram StudentDegreeProgram { get; set; }


    }
}