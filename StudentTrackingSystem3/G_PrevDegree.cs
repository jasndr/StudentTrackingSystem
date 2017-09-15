namespace StudentTrackingSystem3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_PrevDegree
    {
        public int Id { get; set; }

        public int DegreeTypeId { get; set; }

        public string Title { get; set; }

        public decimal GPA { get; set; }

        public string SchoolName { get; set; }

        public string Major { get; set; }

        public string SecondMajor { get; set; }

        public string Minor { get; set; }

        public DateTime DateOfAward { get; set; }

        public int? Student_Id { get; set; }

        public virtual G_CommonFields G_CommonFields { get; set; }

        public virtual G_Student G_Student { get; set; }
    }
}
