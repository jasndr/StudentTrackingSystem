namespace StudentTrackingSystem3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_PersonRaces
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int RaceID { get; set; }

        public bool IsSelectedPR { get; set; }

        public virtual G_Races G_Races { get; set; }

        public virtual G_Student G_Student { get; set; }
    }
}
