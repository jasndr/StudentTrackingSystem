using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTrackingSystem3.Models
{
    public class G_Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int Credits { get; set; }
        public string CourseNum { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<G_Coursework> Coursework { get; set; }

    }
}