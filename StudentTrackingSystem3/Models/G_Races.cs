using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_Races
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Tags { get; set; }
        public bool IsSelected { get; set; }

        public virtual ICollection<G_PersonRaces> PersonRaces { get; set; }

    }
}