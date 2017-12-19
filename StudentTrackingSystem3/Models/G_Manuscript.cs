using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Manuscript
    {
        public int ID { get; set; }
        public int FileID { get; set; }
        [Required, Display(Name = "Received Date")]
        public System.DateTime ReceivedDate {get;set;}
        public virtual G_File File { get; set; }

    }
}