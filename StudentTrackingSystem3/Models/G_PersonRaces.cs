using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_PersonRaces
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int RaceID { get; set; }
        public bool IsSelectedPR { get; set; }


        public virtual G_Student Student { get; set; }
        public virtual G_Races Race { get; set; }
    }
}