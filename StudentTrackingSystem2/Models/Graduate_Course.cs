//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentTrackingSystem2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Graduate_Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Graduate_Course()
        {
            this.Graduate_Coursework = new HashSet<Graduate_Coursework>();
        }
    
        public int Id { get; set; }
        public int Credits { get; set; }
        public string CourseNum { get; set; }
        public string CourseName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_Coursework> Graduate_Coursework { get; set; }
    }
}
