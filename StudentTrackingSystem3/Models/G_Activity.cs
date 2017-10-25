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

        public int PerformanceID { get; set; }
        [StringLength(255), Display(Name="Activity Summary Tab from Student/Mentor")]
        public string ActivitySummaryFileName { get; set; }
        [Display(Name ="Activity Summary Description")]
        public G_FileType ActivitySummaryFileType { get; set; }
        public string ActivitySummaryDesc { get; set; }

        public virtual G_Performance Performance { get; set; }

    }
}