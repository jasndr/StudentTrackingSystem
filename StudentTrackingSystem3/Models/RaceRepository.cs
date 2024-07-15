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

        public static Race Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

        public static IEnumerable<Race> GetAll()
        {

            return new List<Race> {
                new Race {Name=" White / Caucasian", Id=1 },
                new Race {Name=" Black / African American", Id=2 },
                new Race {Name=" Latino / Hispanic", Id=3 },
                new Race {Name=" Native Hawaiian", Id=4 },
                new Race {Name=" Other Pacific Islander", Id=5 },
                new Race {Name=" Native Alaskan", Id=6 },
                new Race {Name=" Native American", Id=7 },
                new Race {Name=" Chinese", Id=8 },
                new Race {Name=" Filipino", Id=9 },
                new Race {Name=" Korean", Id=10 },
                new Race {Name=" Japanese", Id=11 },
                new Race {Name=" Other Asian", Id=12 },
                new Race {Name=" Other", Id=13 },
                new Race {Name=" None Specified", Id=14}
            };

            
        }
        
    }
}