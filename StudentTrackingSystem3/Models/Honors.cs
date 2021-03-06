﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class Honors
    {
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required, Display(Name = "Honor or Award")]
        public string HonorInformation { get; set; }
        [Required, Display(Name = "Honor or Award Month")]
        public int HonorMonthId { get; set; }
        [Required, Display(Name = "Year")]
        public int HonorYear { get; set; }


        public virtual Student Student { get; set; }
        public virtual CommonFields HonorMonth { get; set; }

    }
}