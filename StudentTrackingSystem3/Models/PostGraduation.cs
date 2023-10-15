using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class PostGraduation
    {
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required, Display(Name ="Position")]
        public string CurrentPosition { get; set; }
        [Required, Display(Name ="Start Month")]
        public int CurrentStartMonthId { get; set; }
        [Required, Display(Name = "Start Year")]
        public int CurrentStartYear { get; set; }

        public virtual Student Student { get; set; }
        public virtual CommonFields CurrentStartMonth { get; set; }

    }
}