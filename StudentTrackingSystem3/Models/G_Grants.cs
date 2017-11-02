using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Grants
    {
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required, Display(Name ="Grant Information")]
        public string GrantInformation { get; set; }
        [Required, Display(Name ="Grant Month")]
        public int GrantMonthId { get; set; }
        [Required, Display(Name ="Year")]
        public int GrantYear { get; set; }


        public virtual G_Student Student { get; set; }
        public virtual G_CommonFields GrantMonth { get; set; }
    }
}