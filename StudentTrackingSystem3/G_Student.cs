namespace StudentTrackingSystem3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public G_Student()
        {
            G_Coursework = new HashSet<G_Coursework>();
            G_PersonRaces = new HashSet<G_PersonRaces>();
            G_PrevDegree = new HashSet<G_PrevDegree>();
        }

        public int Id { get; set; }

        public int StudentNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string SchoolEmail { get; set; }

        public string OtherEmail { get; set; }

        public string Phone { get; set; }

        public int? GendersId { get; set; }

        public string RaceOther { get; set; }

        public int? DegreeProgramsId { get; set; }

        public int? ConcentrationsId { get; set; }

        public int? TracksId { get; set; }

        public DateTime DegreeStart { get; set; }

        public DateTime DegreeEnd { get; set; }

        public int? G_CommonFields_ID { get; set; }

        public int? G_CommonFields_ID1 { get; set; }

        public int? G_CommonFields_ID2 { get; set; }

        public int? G_CommonFields_ID3 { get; set; }

        public virtual G_CommonFields G_CommonFields { get; set; }

        public virtual G_CommonFields G_CommonFields1 { get; set; }

        public virtual G_CommonFields G_CommonFields2 { get; set; }

        public virtual G_CommonFields G_CommonFields3 { get; set; }

        public virtual G_CommonFields G_CommonFields4 { get; set; }

        public virtual G_CommonFields G_CommonFields5 { get; set; }

        public virtual G_CommonFields G_CommonFields6 { get; set; }

        public virtual G_CommonFields G_CommonFields7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<G_Coursework> G_Coursework { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<G_PersonRaces> G_PersonRaces { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<G_PrevDegree> G_PrevDegree { get; set; }
    }
}
