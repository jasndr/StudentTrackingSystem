using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentTrackingSystem3.Models;

namespace StudentTrackingSystem3.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {


            var commonfields = new List<G_CommonFields>
            {
                new G_CommonFields {ID=1, Name="Fall", Category="Season", DisplayOrder=1 },
                new G_CommonFields {ID=2, Name="Spring", Category="Season", DisplayOrder=2 },
                new G_CommonFields {ID=3, Name="Summer", Category="Season", DisplayOrder=3 },
                new G_CommonFields {ID=4, Name="A+", Category="Grade", DisplayOrder=1, GradePoint=Decimal.Parse("4.00")},
                new G_CommonFields {ID=5, Name="A", Category="Grade", DisplayOrder=2, GradePoint=Decimal.Parse("4.00")},
                new G_CommonFields {ID=6, Name="A-", Category="Grade", DisplayOrder=3, GradePoint=Decimal.Parse("3.70")},
                new G_CommonFields {ID=7, Name="B+", Category="Grade", DisplayOrder=4, GradePoint=Decimal.Parse("3.30")},
                new G_CommonFields {ID=8, Name="B", Category="Grade", DisplayOrder=5, GradePoint=Decimal.Parse("3.00")},
                new G_CommonFields {ID=9, Name="B-", Category="Grade", DisplayOrder=6, GradePoint=Decimal.Parse("2.70")},
                new G_CommonFields {ID=10, Name="C+", Category="Grade", DisplayOrder=7, GradePoint=Decimal.Parse("2.30")},
                new G_CommonFields {ID=11, Name="C", Category="Grade", DisplayOrder=8, GradePoint=Decimal.Parse("2.00")},
                new G_CommonFields {ID=12, Name="C-", Category="Grade", DisplayOrder=9, GradePoint=Decimal.Parse("1.70")},
                new G_CommonFields {ID=13, Name="D+", Category="Grade", DisplayOrder=10, GradePoint=Decimal.Parse("1.30")},
                new G_CommonFields {ID=14, Name="D", Category="Grade", DisplayOrder=11, GradePoint=Decimal.Parse("1.00")},
                new G_CommonFields {ID=15, Name="D-", Category="Grade", DisplayOrder=12, GradePoint=Decimal.Parse("0.70")},
                new G_CommonFields {ID=16, Name="F", Category="Grade", DisplayOrder=13, GradePoint=Decimal.Parse("0.00")},
                new G_CommonFields {ID=17, Name="MS", Category="DegreeProgram", DisplayOrder=1 },
                new G_CommonFields {ID=18, Name="PhD", Category="DegreeProgram", DisplayOrder=2 },
                new G_CommonFields {ID=19, Name="Clinical Research (CR)", Category="Concentration", DisplayOrder=1 },
                new G_CommonFields {ID=20, Name="Quantitative Health Sciences (QHS)", Category="Concentration", DisplayOrder=2 },
                new G_CommonFields {ID=21, Name="BA", Category="DegreeType", DisplayOrder=1 },
                new G_CommonFields {ID=22, Name="BS", Category="DegreeType", DisplayOrder=2 },
                new G_CommonFields {ID=23, Name="MA", Category="DegreeType", DisplayOrder=3 },
                new G_CommonFields {ID=24, Name="MS", Category="DegreeType", DisplayOrder=4 },
                new G_CommonFields {ID=25, Name="MPH", Category="DegreeType", DisplayOrder=5 },
                new G_CommonFields {ID=26, Name="PhD", Category="DegreeType", DisplayOrder=6 },
                new G_CommonFields {ID=27, Name="DrPH", Category="DegreeType", DisplayOrder=7 },
                new G_CommonFields {ID=28, Name="MD", Category="DegreeType", DisplayOrder=8 },
                new G_CommonFields {ID=29, Name="Plan A", Category="Track", DisplayOrder=1 },
                new G_CommonFields {ID=30, Name="Plan B", Category="Track", DisplayOrder=2 },
                new G_CommonFields {ID=31, Name="Male", Category="Gender", DisplayOrder=1 },
                new G_CommonFields {ID=32, Name="Female", Category="Gender", DisplayOrder=2 }

            };
            commonfields.ForEach(s => context.CommonFields.Add(s));
            context.SaveChanges();

            var courses = new List<G_Course>
            {
                new G_Course { ID=1, CourseNum="BIOM 640", CourseName="Research Methodology", Credits=3 },
                new G_Course { ID=2, CourseNum="BIOM 641", CourseName="Ethics/Cultural Competency/Community-Based Participatory Research", Credits=3},
                new G_Course { ID=3, CourseNum="BIOM 644", CourseName="Translation Methods", Credits=3},
                new G_Course { ID=4, CourseNum="BIOM 645", CourseName="Protocol Development", Credits=3 },
                new G_Course { ID=5, CourseNum="BIOM 646", CourseName="Clinical Research Seminar", Credits=1 },
                new G_Course { ID=6, CourseNum="BIOM 654", CourseName="Molecular Genetics", Credits=2},
                new G_Course { ID=7, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=1 },
                new G_Course { ID=8, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=2 },
                new G_Course { ID=9, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=3 },
                new G_Course { ID=10, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=4 },
                new G_Course { ID=11, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=5 },
                new G_Course { ID=12, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=1 },
                new G_Course { ID=13, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=2 },
                new G_Course { ID=14, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=3 },
                new G_Course { ID=15, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=4 },
                new G_Course { ID=16, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=5 },
                new G_Course { ID=17, CourseNum="CAAM 401", CourseName="Mindfulness", Credits=1 },
                new G_Course { ID=18, CourseNum="CAAM 415", CourseName="Nutrition", Credits=3 },
                new G_Course { ID=19, CourseNum="CAAM 445", CourseName="Integrative Medicine", Credits=3 },
                new G_Course { ID=20, CourseNum="ICS 614", CourseName="Biomedical Informatics", Credits=3 },
                new G_Course { ID=21, CourseNum="ICS 635", CourseName="Machine Learning", Credits=3 },
                new G_Course { ID=22, CourseNum="PH 659", CourseName="Methods of Demographic Analysis", Credits=3 },
                new G_Course { ID=23, CourseNum="PH 663", CourseName="Principles of Epidemiology", Credits=3 },
                new G_Course { ID=24, CourseNum="PH 747", CourseName="Statistical Methods in Epidemiology Research", Credits=3 },
                new G_Course { ID=25, CourseNum="PH 748", CourseName="Chronic Disease Epidemiology", Credits=3},
                new G_Course { ID=26, CourseNum="QHS 601", CourseName="Biostatistics I", Credits=3},
                new G_Course { ID=27, CourseNum="QHS 602", CourseName="Biostatistics II", Credits=3},
                new G_Course { ID=28, CourseNum="QHS 610", CourseName="Bioinformatics I", Credits=3},
                new G_Course { ID=29, CourseNum="QHS 611", CourseName="Bioinformatics II", Credits=3},
                new G_Course { ID=30, CourseNum="QHS 620", CourseName="Introduction to Clinical Trials", Credits=2},
                new G_Course { ID=31, CourseNum="QHS 621", CourseName="Analysis of Clinical Trials", Credits=2 },
                new G_Course { ID=32, CourseNum="QHS 650", CourseName="Secondary Data Analysis", Credits=2},
                new G_Course { ID=33, CourseNum="QHS 651", CourseName="Secondary Data Analysis Practicum", Credits=1 },
                new G_Course { ID=34, CourseNum="QHS 699", CourseName="Directed Research", Credits=1 },
                new G_Course { ID=35, CourseNum="QHS 699", CourseName="Directed Research", Credits=2 },
                new G_Course { ID=36, CourseNum="QHS 699", CourseName="Directed Research", Credits=3 },
                new G_Course { ID=37, CourseNum="QHS 699", CourseName="Directed Research", Credits=4 },
                new G_Course { ID=38, CourseNum="QHS 699", CourseName="Directed Research", Credits=5 }
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var students = new List<G_Student>
            {
                new G_Student {Id=1, StudentNumber=10000001, FirstName="Carson", MiddleName="John", LastName="Alexander", SchoolEmail="carsonja@hawaii.edu", OtherEmail="carson_alexander@gmail.com", Phone="(808) 546-2455", DegreeStart=DateTime.Parse("2005-08-22"), DegreeEnd=DateTime.Parse("2007-05-15"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=18, TracksId=30},
                new G_Student {Id=2, StudentNumber=10000002, FirstName="Meredith", MiddleName="Mary", LastName="Alonso", SchoolEmail="alonsomm@hawaii.edu", OtherEmail="mereditha@yahoo.com", Phone="(808) 942-3333", DegreeStart=DateTime.Parse("2002-08-25"), DegreeEnd=DateTime.Parse("2004-05-13"), ConcentrationsId=20, GendersId=32, DegreeProgramsId=17, TracksId=29},
                new G_Student {Id=3, StudentNumber=10000003, FirstName="Arturo", MiddleName="Javier", LastName="Anand", SchoolEmail="arturoja@hawaii.edu", OtherEmail="anand_arturo@outlook.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=4, StudentNumber=10000004, FirstName="Magdalena", MiddleName="Ochorro", LastName="Butelera", SchoolEmail="butelera@hawaii.edu", OtherEmail="lenny_butelera@outlook.com", Phone="(510) 268-5272", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=5, StudentNumber=10000005, FirstName="Angela", MiddleName="Zara", LastName="Amaranda", SchoolEmail="amaranda@hawaii.edu", OtherEmail="angela_amaranda@outlook.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=6, StudentNumber=10000006, FirstName="Faith", MiddleName="Mae", LastName="Ping", SchoolEmail="fmaeping@hawaii.edu", OtherEmail="faithMaePing@outlook.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=7, StudentNumber=10000007, FirstName="Marcus", MiddleName="Wyatt", LastName="O'Neil", SchoolEmail="oneilmw@hawaii.edu", OtherEmail="markoneil@outlook.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=8, StudentNumber=10000008, FirstName="Michael", MiddleName="Gravy", LastName="MacDonald", SchoolEmail="mikemac@hawaii.edu", OtherEmail="gravy@gmail.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=9, StudentNumber=10000009, FirstName="Barry", MiddleName="Christoff", LastName="Smith", SchoolEmail="barrycsm@hawaii.edu", OtherEmail="barrysmith@gmail.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=10, StudentNumber=10000010, FirstName="Chuck", MiddleName="Charles", LastName="Churchill", SchoolEmail="chuckcc@hawaii.edu", OtherEmail="chuckcharles@church.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=11, StudentNumber=10000011, FirstName="Rodolfo", MiddleName="Portrero", LastName="Santos", SchoolEmail="portrero@hawaii.edu", OtherEmail="rodolfo_santos@yahoo.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=12, StudentNumber=10000012, FirstName="Jacques", MiddleName="Jean", LastName="Bordereaux", SchoolEmail="jacquesb@hawaii.edu", OtherEmail="bordereaux@gmail.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=13, StudentNumber=10000013, FirstName="Oliver", MiddleName="Quincy", LastName="Potter", SchoolEmail="oqpotter@hawaii.edu", OtherEmail="olipotter@yahoo.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=14, StudentNumber=10000014, FirstName="Fanasa", MiddleName="Borda", LastName="Marta", SchoolEmail="borda@hawaii.edu", OtherEmail="fanasia_bordamarta@outlook.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=15, StudentNumber=10000015, FirstName="Amy", MiddleName="Kiya", LastName="Novikov", SchoolEmail="amykiyan@hawaii.edu", OtherEmail="amykia@gmail.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=16, StudentNumber=10000016, FirstName="Mary", MiddleName="Margarette", LastName="Marchentero", SchoolEmail="marchente@hawaii.edu", OtherEmail="mmm@ymail.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=17, StudentNumber=10000017, FirstName="Ying", MiddleName="Jie", LastName="Xong", SchoolEmail="yingjiex@hawaii.edu", OtherEmail="yingjie@outlook.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=18, StudentNumber=10000018, FirstName="Sakura", MiddleName="Noburi", LastName="Ichiyama", SchoolEmail="sakurani@hawaii.edu", OtherEmail="noburi@yahoo.co.jp", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=19, StudentNumber=10000019, FirstName="Sayuri", MiddleName="Misa", LastName="Katsumoto", SchoolEmail="sayurimk@hawaii.edu", OtherEmail="katsumoto.sayuri@yahoo.co.jp", Phone="(808) 482-2832", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=20, StudentNumber=10000020, FirstName="Ton", MiddleName="Ton", LastName="Balatong", SchoolEmail="tontonb@hawaii.edu", OtherEmail="ton2balatong@gmail.com.com", Phone="(329) 283-4822", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=21, StudentNumber=10000021, FirstName="Laura", MiddleName="Windham", LastName="Correa", SchoolEmail="lwcorrea@hawaii.edu", OtherEmail="laura_correa@yahoo.com", Phone="(348) 283-2384", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30},
                new G_Student {Id=22, StudentNumber=10000022, FirstName="Xi", MiddleName="Xang", LastName="Xu", SchoolEmail="xxx@hawaii.edu", OtherEmail="xixangxu@wechat.ch", Phone="(516) 278-5295", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10"), ConcentrationsId=19, GendersId=31, DegreeProgramsId=17, TracksId=30}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();


            var coursework = new List<G_Coursework>
            {
                new G_Coursework {StudentID=1, SemestersID=1, Year=2005, CourseID=15, GradeID=4},
                new G_Coursework {StudentID=1, SemestersID=2, Year=2006, CourseID=26, GradeID=7},
                new G_Coursework {StudentID=1, SemestersID=1, Year=2006, CourseID=1,  GradeID=10},
                new G_Coursework {StudentID=1, SemestersID=2, Year=2007, CourseID=23, GradeID=8},
                new G_Coursework {StudentID=1, SemestersID=1, Year=2007, CourseID=16, GradeID=5},
                new G_Coursework {StudentID=2, SemestersID=1, Year=2002, CourseID=20, GradeID=5},
                new G_Coursework {StudentID=2, SemestersID=2, Year=2003, CourseID=15, GradeID=7},
                new G_Coursework {StudentID=2, SemestersID=1, Year=2003, CourseID=10, GradeID=4},
                new G_Coursework {StudentID=3, SemestersID=3, Year=2003, CourseID=30, GradeID=9},
                new G_Coursework {StudentID=3, SemestersID=2, Year=2003, CourseID=1,  GradeID=12},
                new G_Coursework {StudentID=3, SemestersID=1, Year=2003, CourseID=15, GradeID=13},
                new G_Coursework {StudentID=3, SemestersID=2, Year=2004, CourseID=31, GradeID=16}


            };
            coursework.ForEach(s => context.Coursework.Add(s));
            context.SaveChanges();


            var races = new List<G_Races>
            {
                new G_Races {Id=1, Name="White / Caucasian"},
                new G_Races {Id=2, Name="Black / African American"},
                new G_Races {Id=3, Name="Latino / Hispanic"},
                new G_Races {Id=4, Name="Native Hawaiian" },
                new G_Races {Id=5, Name="Other Pacific Islander" },
                new G_Races {Id=6, Name="Native Alaskan"},
                new G_Races {Id=7, Name="Native American"},
                new G_Races {Id=8, Name="Chinese" },
                new G_Races {Id=9, Name="Filipino"},
                new G_Races {Id=10, Name="Korean"},
                new G_Races {Id=11, Name="Japanese" },
                new G_Races {Id=12, Name="Other Asian"},
                new G_Races {Id=13, Name="Other"}
            };
            races.ForEach(s => context.Races.Add(s));
            context.SaveChanges();

            var personRaces = new List<G_PersonRaces>
            {
                new G_PersonRaces {ID=1, StudentID=1, RaceID=3, IsSelectedPR=true},
                new G_PersonRaces {ID=2, StudentID=1, RaceID=1, IsSelectedPR=true},
                new G_PersonRaces {ID=3, StudentID=1, RaceID=7, IsSelectedPR=true},
                new G_PersonRaces {ID=4, StudentID=2, RaceID=10, IsSelectedPR=true},
                new G_PersonRaces {ID=5, StudentID=3, RaceID=4, IsSelectedPR=true},
                new G_PersonRaces {ID=6, StudentID=3, RaceID=2, IsSelectedPR=true}
            };

            races.ForEach(s => context.Races.Add(s));
            context.SaveChanges();

        }

    }
}