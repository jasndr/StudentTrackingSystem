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

        public static Races Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

        public static IEnumerable<Races> GetAll()
        {

            return new List<Races> {
                new Races {Name=" White / Caucasian", Id=1 },
                new Races {Name=" Black / African American", Id=2 },
                new Races {Name=" Latino / Hispanic", Id=3 },
                new Races {Name=" Native Hawaiian", Id=4 },
                new Races {Name=" Other Pacific Islander", Id=5 },
                new Races {Name=" Native Alaskan", Id=6 },
                new Races {Name=" Native American", Id=7 },
                new Races {Name=" Chinese", Id=8 },
                new Races {Name=" Filipino", Id=9 },
                new Races {Name=" Korean", Id=10 },
                new Races {Name=" Japanese", Id=11 },
                new Races {Name=" Other Asian", Id=12 },
                new Races {Name=" Other", Id=13 }
            };

            
        }
        
    }
}