//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentTrackingSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Graduate_CommonFields
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Graduate_CommonFields()
        {
            this.Graduate_Student = new HashSet<Graduate_Student>();
            this.Graduate_Student1 = new HashSet<Graduate_Student>();
            this.Graduate_Student2 = new HashSet<Graduate_Student>();
            this.Graduate_Student3 = new HashSet<Graduate_Student>();
            this.Graduate_Class = new HashSet<Graduate_Class>();
            this.Graduate_Semester = new HashSet<Graduate_Semester>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DisplayOrder { get; set; }
        public Nullable<decimal> GradePoint { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Student> Graduate_Student { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Student> Graduate_Student1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Student> Graduate_Student2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Student> Graduate_Student3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Class> Graduate_Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Semester> Graduate_Semester { get; set; }
    }
}
