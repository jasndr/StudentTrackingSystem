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
    
    public partial class Graduate_Races
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Graduate_Races()
        {
            this.Graduate_PersonRace = new HashSet<Graduate_PersonRace>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        //Manually inserted
        public object Tags { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Graduate_PersonRace> Graduate_PersonRace { get; set; }
    }
}
