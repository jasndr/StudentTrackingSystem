using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Activity
    {

        public int ID { get; set; }
        public int StudentID { get; set; }
        [Display(Name="Activity Summary Tab from Student/Mentor")]
        public byte[] ActivitySummaryFile { get; set; }
        [Display(Name ="Activity Summary Description")]
        public string ActivitySummaryDesc { get; set; }

        public virtual G_Student Student { get; set; }

    }
}