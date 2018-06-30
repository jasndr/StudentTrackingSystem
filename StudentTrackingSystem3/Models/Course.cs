using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTrackingSystem3.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int Credits { get; set; }
        [Display(Name="Course")]
        public string CourseNum { get; set; }
        [Display(Name = "Title")]
        public string CourseName { get; set; }

        public virtual ICollection<Coursework> Coursework { get; set; }

    }
}