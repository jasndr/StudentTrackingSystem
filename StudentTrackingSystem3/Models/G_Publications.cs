using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Publications
    {
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required, Display(Name ="Publication")]
        public string PublicationInformation{ get; set; }
        [Required, Display(Name ="Publication Month")]
        public int PubMonthId { get; set; }
        [Required, Display(Name ="Year")]
        public int PubYear { get; set; }

        public virtual G_Student Student { get; set; }
        public virtual G_CommonFields PubMonth { get; set; }
        
    }
}