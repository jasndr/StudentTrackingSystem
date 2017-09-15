namespace StudentTrackingSystem3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_Coursework
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int SemestersID { get; set; }

        public int Year { get; set; }

        public int CourseID { get; set; }

        public int? Grade { get; set; }

        public virtual G_CommonFields G_CommonFields { get; set; }

        public virtual G_Course G_Course { get; set; }

        public virtual G_Student G_Student { get; set; }
    }
}
