using StudentTrackingSystem3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public static class RaceRepository
    {
        //private static SchoolContext db = new SchoolContext();

        public static G_Races Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

        public static IEnumerable<G_Races> GetAll()
        {

            return new List<G_Races> {
                new G_Races {Name=" White / Caucasian", Id=1 },
                new G_Races {Name=" Black / African American", Id=2 },
                new G_Races {Name=" Latino / Hispanic", Id=3 },
                new G_Races {Name=" Native Hawaiian", Id=4 },
                new G_Races {Name=" Other Pacific Islander", Id=5 },
                new G_Races {Name=" Native Alaskan", Id=6 },
                new G_Races {Name=" Native American", Id=7 },
                new G_Races {Name=" Chinese", Id=8 },
                new G_Races {Name=" Filipino", Id=9 },
                new G_Races {Name=" Korean", Id=10 },
                new G_Races {Name=" Japanese", Id=11 },
                new G_Races {Name=" Other Asian", Id=12 },
                new G_Races {Name=" Other", Id=13 }
            };

            
        }
        
    }
}