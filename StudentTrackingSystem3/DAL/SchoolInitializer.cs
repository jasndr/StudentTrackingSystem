using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentTrackingSystem3.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace StudentTrackingSystem3.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {


            var commonfields = new List<CommonFields>
            {
               new CommonFields {ID=1, Name="Spring", Category="Season", DisplayOrder=1 },
                new CommonFields {ID=2, Name="Summer", Category="Season", DisplayOrder=2 },
                new CommonFields {ID=3, Name="Fall", Category="Season", DisplayOrder=3 },
                new CommonFields {ID=4, Name="A+", Category="Grade", DisplayOrder=1, GradePoint=Decimal.Parse("4.00")},
                new CommonFields {ID=5, Name="A", Category="Grade", DisplayOrder=2, GradePoint=Decimal.Parse("4.00")},
                new CommonFields {ID=6, Name="A-", Category="Grade", DisplayOrder=3, GradePoint=Decimal.Parse("3.70")},
                new CommonFields {ID=7, Name="B+", Category="Grade", DisplayOrder=4, GradePoint=Decimal.Parse("3.30")},
                new CommonFields {ID=8, Name="B", Category="Grade", DisplayOrder=5, GradePoint=Decimal.Parse("3.00")},
                new CommonFields {ID=9, Name="B-", Category="Grade", DisplayOrder=6, GradePoint=Decimal.Parse("2.70")},
                new CommonFields {ID=10, Name="C+", Category="Grade", DisplayOrder=7, GradePoint=Decimal.Parse("2.30")},
                new CommonFields {ID=11, Name="C", Category="Grade", DisplayOrder=8, GradePoint=Decimal.Parse("2.00")},
                new CommonFields {ID=12, Name="C-", Category="Grade", DisplayOrder=9, GradePoint=Decimal.Parse("1.70")},
                new CommonFields {ID=13, Name="D+", Category="Grade", DisplayOrder=10, GradePoint=Decimal.Parse("1.30")},
                new CommonFields {ID=14, Name="D", Category="Grade", DisplayOrder=11, GradePoint=Decimal.Parse("1.00")},
                new CommonFields {ID=15, Name="D-", Category="Grade", DisplayOrder=12, GradePoint=Decimal.Parse("0.70")},
                new CommonFields {ID=16, Name="F", Category="Grade", DisplayOrder=13, GradePoint=Decimal.Parse("0.00")},
                new CommonFields {ID=17, Name="MS", Category="DegreeProgram", DisplayOrder=1 },
                new CommonFields {ID=18, Name="GCERT", Category="DegreeProgram", DisplayOrder=2 },
                new CommonFields {ID=19, Name="Clinical Research (CR)", Category="Track", DisplayOrder=1 },
                new CommonFields {ID=20, Name="Quantitative Health Sciences (QHS)", Category="Track", DisplayOrder=2 },
                new CommonFields {ID=21, Name="BA", Category="DegreeType", DisplayOrder=1 },
                new CommonFields {ID=22, Name="BS", Category="DegreeType", DisplayOrder=2 },
                new CommonFields {ID=23, Name="MA", Category="DegreeType", DisplayOrder=3 },
                new CommonFields {ID=24, Name="MS", Category="DegreeType", DisplayOrder=4 },
                new CommonFields {ID=25, Name="MPH", Category="DegreeType", DisplayOrder=5 },
                new CommonFields {ID=26, Name="PhD", Category="DegreeType", DisplayOrder=6 },
                new CommonFields {ID=27, Name="DrPH", Category="DegreeType", DisplayOrder=7 },
                new CommonFields {ID=28, Name="MD", Category="DegreeType", DisplayOrder=8 },
                new CommonFields {ID=29, Name="Plan A", Category="Plan", DisplayOrder=1 },
                new CommonFields {ID=30, Name="Plan B", Category="Plan", DisplayOrder=2 },
                new CommonFields {ID=31, Name="Male", Category="Gender", DisplayOrder=1 },
                new CommonFields {ID=32, Name="Female", Category="Gender", DisplayOrder=2 },
                new CommonFields {ID=33, Name="Published", Category="Publication", DisplayOrder=1 },
                new CommonFields {ID=34, Name="Accepted", Category="Publication", DisplayOrder=2 },
                new CommonFields {ID=35, Name="Submitted", Category="Publication", DisplayOrder=3 },
                new CommonFields {ID=36, Name="In Preparation", Category="Publication", DisplayOrder=4 },
                new CommonFields {ID=37, Name="Funded", Category="Proposal", DisplayOrder=1 },
                new CommonFields {ID=38, Name="Submitted", Category="Proposal", DisplayOrder=2 },
                new CommonFields {ID=39, Name="In Preparation", Category="Proposal", DisplayOrder=3 },
                new CommonFields {ID=40, Name="Instructor", Category="Teaching", DisplayOrder=1 },
                new CommonFields {ID=41, Name="TA", Category="Teaching", DisplayOrder=2 },
                new CommonFields {ID=42, Name="Publication", Category="PerformanceCategory", DisplayOrder=1  },
                new CommonFields {ID=43, Name="Abstract", Category="PerformanceCategory", DisplayOrder=1  },
                new CommonFields {ID=44, Name="Proposal", Category="PerformanceCategory", DisplayOrder=3  },
                new CommonFields {ID=45, Name="Teaching", Category="PerformanceCategory", DisplayOrder=4  },
                new CommonFields {ID=46, Name="Pass", Category="QualifierResult", DisplayOrder=1},
                new CommonFields {ID=47, Name="Fail", Category="QualifierResult", DisplayOrder=2},
                new CommonFields {ID=48, Name="Comprehensive Exam", Category="Form2Type", DisplayOrder=1 },
                new CommonFields {ID=49, Name="Proposal Presentation", Category="Form2Type", DisplayOrder=2 },
                new CommonFields {ID=50, Name="Pass", Category="Form2Result", DisplayOrder=1 },
                new CommonFields {ID=51, Name="Partial Pass", Category="Form2Result", DisplayOrder=2 },
                new CommonFields {ID=52, Name="Fail", Category="Form2Result", DisplayOrder=3 },
                new CommonFields {ID=53, Name="Thesis", Category="CommitteeType", DisplayOrder=1 },
                new CommonFields {ID=54, Name="Dissertation", Category="CommitteeType", DisplayOrder=2 },
                new CommonFields {ID=55, Name="January", Category="Months", DisplayOrder=1 },
                new CommonFields {ID=56, Name="February", Category="Months", DisplayOrder=2 },
                new CommonFields {ID=57, Name="March", Category="Months", DisplayOrder=3 },
                new CommonFields {ID=58, Name="April", Category="Months", DisplayOrder=4 },
                new CommonFields {ID=59, Name="May", Category="Months", DisplayOrder=5 },
                new CommonFields {ID=60, Name="June", Category="Months", DisplayOrder=6 },
                new CommonFields {ID=61, Name="July", Category="Months", DisplayOrder=7 },
                new CommonFields {ID=62, Name="August", Category="Months", DisplayOrder=8 },
                new CommonFields {ID=63, Name="September", Category="Months", DisplayOrder=9 },
                new CommonFields {ID=64, Name="October", Category="Months", DisplayOrder=10 },
                new CommonFields {ID=65, Name="November", Category="Months", DisplayOrder=11 },
                new CommonFields {ID=66, Name="December", Category="Months", DisplayOrder=12 },
                new CommonFields{ID=67, Name="US", Category="CitizenshipStatus", DisplayOrder=1},
                new CommonFields{ID=68, Name="Visa", Category="CitizenshipStatus", DisplayOrder=2},
                new CommonFields{ID=69, Name="Permanent Resident", Category="CitizenshipStatus", DisplayOrder=3},
                new CommonFields{ID=70, Name="Full-Time", Category="EmploymentStatus", DisplayOrder=1},
                new CommonFields{ID=71, Name="Part-Time", Category="EmploymentStatus", DisplayOrder=2},
                new CommonFields{ID=72, Name="Unemployed", Category="EmploymentStatus", DisplayOrder=3},
                new CommonFields{ID=73, Name="Unknown", Category="EmploymentStatus", DisplayOrder=4},
                new CommonFields{ID=74, Name="Hyeong Jun Ahn", Category="MsctrFaculty", DisplayOrder=1},
                new CommonFields{ID=75, Name="Amy Brown", Category="MsctrFaculty", DisplayOrder=2},
                new CommonFields{ID=76, Name="John Chen", Category="MsctrFaculty", DisplayOrder=3},
                new CommonFields{ID=77, Name="Katalin Csiszar", Category="MsctrFaculty", DisplayOrder=4},
                new CommonFields{ID=78, Name="James Davis", Category="MsctrFaculty", DisplayOrder=5},
                new CommonFields{ID=79, Name="Youping Deng", Category="MsctrFaculty", DisplayOrder=6},
                new CommonFields{ID=80, Name="Vedbar Khadka", Category="MsctrFaculty", DisplayOrder=7},
                new CommonFields{ID=81, Name="Eunjung Lim", Category="MsctrFaculty", DisplayOrder=8},
                new CommonFields{ID=82, Name="Chathura Siriwardhana", Category="MsctrFaculty", DisplayOrder=9},
                new CommonFields{ID=83, Name="CR", Category="CourseTrack", DisplayOrder=1},
                new CommonFields{ID=84, Name="QHS", Category="CourseTrack", DisplayOrder=2},
                new CommonFields{ID=85, Name="Both", Category="CourseTrack", DisplayOrder=3},
                new CommonFields{ID=86, Name="Elective", Category="CourseTrack", DisplayOrder=4},
                new CommonFields{ID=87, Name="Plan A", Category="CoursePlan", DisplayOrder=1},
                new CommonFields{ID=88, Name="Plan B", Category="CoursePlan", DisplayOrder=2},
                new CommonFields{ID=89, Name="Both", Category="CoursePlan", DisplayOrder=3},
                //new CommonFields{ID=90, Name="N/A", Category="CoursePlan", DisplayOrder=4}

            };
            commonfields.ForEach(s => context.CommonFields.Add(s));
            SaveChanges(context);

            var courses = new List<Course>
            {
                new Course { ID=1, CourseNum="BIOM 640", CourseName="Research Methodology"}, // CourseTrackID =85 , CoursePlanID=89  },
                new Course { ID=2, CourseNum="BIOM 641", CourseName="Ethics/Cultural Competency/Community-Based Participatory Research"}, // CourseTrackID=83 , CoursePlanID=89},
                new Course { ID=3, CourseNum="BIOM 644", CourseName="Translation Methods" },// CourseTrackID =85 , CoursePlanID=89  },
                new Course { ID=4, CourseNum="BIOM 645", CourseName="Protocol Development"}, // CourseTrackID=83 , CoursePlanID=89 },
                new Course { ID=5, CourseNum="BIOM 646", CourseName="Clinical Research Seminar"}, // CourseTrackID =85 , CoursePlanID=89  },
                new Course { ID=35, CourseNum="BIOM 647", CourseName="Cultural Competence in Biomedical Research I"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=6, CourseNum="BIOM 654", CourseName="Molecular Genetics"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=7, CourseNum="BIOM 699", CourseName="Directed Reading"}, // CourseTrackID=85 , CoursePlanID=89 },
                //new Course { ID=8, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=2 },
                //new Course { ID=9, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=3 },
                //new Course { ID=10, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=4 },
                //new Course { ID=11, CourseNum="BIOM 699", CourseName="Directed Reading", Credits=5 },
                new Course { ID=12, CourseNum="BIOM 700", CourseName="Thesis Research"}, // CourseTrackID=85 , CoursePlanID=87 },
                //new Course { ID=13, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=2 },
                //new Course { ID=14, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=3 },
                //new Course { ID=15, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=4 },
                //new Course { ID=16, CourseNum="BIOM 700", CourseName="Thesis Research", Credits=5 },
                new Course { ID=17, CourseNum="CAAM 401", CourseName="Mindfulness"}, // CourseTrackID=86 , CoursePlanID=89 },
                //new Course { ID=18, CourseNum="CAAM 415", CourseName="Nutrition", Credits=3 },
                new Course { ID=19, CourseNum="CAAM 445", CourseName="Integrative Medicine"}, // CourseTrackID=86 , CoursePlanID=89 },
                new Course { ID=39, CourseNum="CMB 606", CourseName="Introduction to Neurosciences"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=40, CourseNum="CMB 625", CourseName="Advanced Topics in Genetics"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=41, CourseNum="CMB 640", CourseName="Neuropharmacology"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=42, CourseNum="GEOG 388", CourseName="Introduction to GIS"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=43, CourseNum="GEOG 389", CourseName="GIS Data Visualization"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=44, CourseNum="GEOG 489", CourseName="Applied Geographic Information Systems"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=45, CourseNum="GEOG 680", CourseName="Geospatial Analysis of Natural Resource Data"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=20, CourseNum="ICS 614", CourseName="Biomedical Informatics"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=46, CourseNum="ICS 624", CourseName="Advanced Data Management"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=21, CourseNum="ICS 635", CourseName="Machine Learning"}, // CourseTrackID=86 , CoursePlanID=89 },
                new Course { ID=47, CourseNum="ICS 663", CourseName="Pattern Recognition"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=48, CourseNum="MBBE 650", CourseName="DNA and Genetic Analysis"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=49, CourseNum="MBBE 683", CourseName="Advanced Bioinformatics Topics for Biologists"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=50, CourseNum="PH 650", CourseName="Ecological Epidemiology"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=51, CourseNum="PH 658", CourseName="Computer Applications in Public Health"}, // CourseTrackID=86 , CoursePlanID=89},
                //new Course { ID=22, CourseNum="PH 659", CourseName="Methods of Demographic Analysis", Credits=3 },
                new Course { ID=23, CourseNum="PH 663", CourseName="Principles of Epidemiology I", Credits=3 },
                new Course { ID=52, CourseNum="PH 664", CourseName="Principles of Epidemiology II"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=53, CourseNum="PH 669", CourseName="Epidemiology Study Design Critique"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=54, CourseNum="PH 689", CourseName="Nutritional Epidemiology"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=24, CourseNum="PH 747", CourseName="Statistical Methods in Epidemiology Research"}, // CourseTrackID=86 , CoursePlanID=89 },
                new Course { ID=25, CourseNum="PH 748", CourseName="Chronic Disease Epidemiology", Credits=3},
                new Course { ID=26, CourseNum="QHS 601", CourseName="Biostatistics I"}, // CourseTrackID =85 , CoursePlanID=89  },
                new Course { ID=27, CourseNum="QHS 602", CourseName="Biostatistics II"}, // CourseTrackID =85 , CoursePlanID=89  },
                new Course { ID=28, CourseNum="QHS 610", CourseName="Bioinformatics I"}, // CourseTrackID=84 , CoursePlanID=89 },
                new Course { ID=29, CourseNum="QHS 611", CourseName="Bioinformatics II"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=30, CourseNum="QHS 620", CourseName="Introduction to Clinical Trials"}, // CourseTrackID=83 , CoursePlanID=89 },
                new Course { ID=31, CourseNum="QHS 621", CourseName="Analysis of Clinical Trials"}, // CourseTrackID=84 , CoursePlanID=89 },
                new Course { ID=32, CourseNum="QHS 650", CourseName="Secondary Data Analysis"}, // CourseTrackID=84 , CoursePlanID=89},
                new Course { ID=33, CourseNum="QHS 651", CourseName="Secondary Data Analysis Practicum"}, // CourseTrackID=86 , CoursePlanID=89 },
                new Course { ID=36, CourseNum="QHS 670", CourseName="Special Topics in Quantitative Health"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=37, CourseNum="QHS 675", CourseName="Biostatistical Consulting"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=38, CourseNum="QHS 676", CourseName="Biostatistical Consulting Practicum"}, // CourseTrackID=86 , CoursePlanID=89},
                new Course { ID=34, CourseNum="QHS 699", CourseName="Directed Research"}, // CourseTrackID=84 , CoursePlanID=88},
                new Course { ID=55, CourseNum="TRMD 675", CourseName="Epidemiology of Tropical Infectious Diseases"}, // CourseTrackID=86, CoursePlanID=89}
                //new Course { ID=35, CourseNum="QHS 699", CourseName="Directed Research", Credits=2 },
                //new Course { ID=36, CourseNum="QHS 699", CourseName="Directed Research", Credits=3 },
                //new Course { ID=37, CourseNum="QHS 699", CourseName="Directed Research", Credits=4 },
                //new Course { ID=38, CourseNum="QHS 699", CourseName="Directed Research", Credits=5 }
            };
            courses.ForEach(s => context.Courses.Add(s));
            SaveChanges(context);

            var students = new List<Student>
            {
                new Student {Id=1,  StudentNumber=10000001, FirstName="Carson", MiddleName="John", LastName="Alexander", SchoolEmail="carsonja@hawaii.edu", OtherEmail="carson_alexander@gmail.com", Phone="(808) 546-2455",      GendersId=31, DegreeProgramsId=17, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2009},
                new Student {Id=2,  StudentNumber=10000002, FirstName="Meredith", MiddleName="Mary", LastName="Alonso", SchoolEmail="alonsomm@hawaii.edu", OtherEmail="mereditha@yahoo.com", Phone="(808) 942-3333",              GendersId=32, DegreeProgramsId=18, TracksId=20, PlansId=30, DegreeStartSemsId=1, DegreeStartYear=2002},
                new Student {Id=3,  StudentNumber=10000003, FirstName="Arturo", MiddleName="Javier", LastName="Anand", SchoolEmail="arturoja@hawaii.edu", OtherEmail="anand_arturo@outlook.com", Phone="(919) 546-7562",          GendersId=31, DegreeProgramsId=17, TracksId=20, PlansId=29, DegreeStartSemsId=2, DegreeStartYear=2003},
                new Student {Id=4,  StudentNumber=10000004, FirstName="Magdalena", MiddleName="Ochorro", LastName="Butelera", SchoolEmail="butelera@hawaii.edu", OtherEmail="lenny_butelera@outlook.com", Phone="(510) 268-5272", GendersId=32, DegreeProgramsId=17, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2004},
                new Student {Id=5,  StudentNumber=10000005, FirstName="Angela", MiddleName="Zara", LastName="Amaranda", SchoolEmail="amaranda@hawaii.edu", OtherEmail="angela_amaranda@outlook.com", Phone="(919) 546-7562",      GendersId=31, DegreeProgramsId=18, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2005},
                new Student {Id=6,  StudentNumber=10000006, FirstName="Faith", MiddleName="Mae", LastName="Ping", SchoolEmail="fmaeping@hawaii.edu", OtherEmail="faithMaePing@outlook.com", Phone="(929) 526-2051",               GendersId=32, DegreeProgramsId=17, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2004},
                new Student {Id=7,  StudentNumber=10000007, FirstName="Marcus", MiddleName="Wyatt", LastName="O'Neil", SchoolEmail="oneilmw@hawaii.edu", OtherEmail="markoneil@outlook.com", Phone="(285) 456-7683",              GendersId=31, DegreeProgramsId=17, TracksId=19, PlansId=30, DegreeStartSemsId=2, DegreeStartYear=2003},
                new Student {Id=8,  StudentNumber=10000008, FirstName="Michael", MiddleName="Gravy", LastName="MacDonald", SchoolEmail="mikemac@hawaii.edu", OtherEmail="gravy@gmail.com", Phone="(808) 649-7632",                GendersId=31, DegreeProgramsId=18, TracksId=20, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2012},
                new Student {Id=9,  StudentNumber=10000009, FirstName="Barry", MiddleName="Christoff", LastName="Smith", SchoolEmail="barrycsm@hawaii.edu", OtherEmail="barrysmith@gmail.com", Phone="(808) 686-8532",            GendersId=31, DegreeProgramsId=18, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2013},
                new Student {Id=10, StudentNumber=10000010, FirstName="Chuck", MiddleName="Charles", LastName="Churchill", SchoolEmail="chuckcc@hawaii.edu", OtherEmail="chuckcharles@church.com", Phone="(808) 482-2852",        GendersId=31, DegreeProgramsId=17, TracksId=19, PlansId=30, DegreeStartSemsId=1, DegreeStartYear=2016},
                new Student {Id=11, StudentNumber=10000011, FirstName="Rodolfo", MiddleName="Portrero", LastName="Santos", SchoolEmail="portrero@hawaii.edu", OtherEmail="rodolfo_santos@yahoo.com", Phone="(919) 356-4124",      GendersId=31, DegreeProgramsId=18, TracksId=19, PlansId=29, DegreeStartSemsId=2, DegreeStartYear=2015},
                new Student {Id=12, StudentNumber=10000012, FirstName="Jacques", MiddleName="Jean", LastName="Bordereaux", SchoolEmail="jacquesb@hawaii.edu", OtherEmail="bordereaux@gmail.com", Phone="(919) 620-2647",          GendersId=31, DegreeProgramsId=18, TracksId=20, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2017},
                new Student {Id=13, StudentNumber=10000013, FirstName="Oliver", MiddleName="Quincy", LastName="Potter", SchoolEmail="oqpotter@hawaii.edu", OtherEmail="olipotter@yahoo.com", Phone="(853) 371-4224",              GendersId=31, DegreeProgramsId=17, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2015},
                new Student {Id=14, StudentNumber=10000014, FirstName="Fanasa", MiddleName="Borda", LastName="Marta", SchoolEmail="borda@hawaii.edu", OtherEmail="fanasia_bordamarta@outlook.com", Phone="(415) 654-3718",        GendersId=32, DegreeProgramsId=18, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2016},
                new Student {Id=15, StudentNumber=10000015, FirstName="Amy", MiddleName="Kiya", LastName="Novikov", SchoolEmail="amykiyan@hawaii.edu", OtherEmail="amykia@gmail.com", Phone="(808) 421-5284",                     GendersId=32, DegreeProgramsId=17, TracksId=20, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2018},
                new Student {Id=16, StudentNumber=10000016, FirstName="Mary", MiddleName="Margarette", LastName="Marchentero", SchoolEmail="marchente@hawaii.edu", OtherEmail="mmm@ymail.com", Phone="(825) 213-3547",            GendersId=32, DegreeProgramsId=17, TracksId=19, PlansId=30, DegreeStartSemsId=1, DegreeStartYear=2017},
                new Student {Id=17, StudentNumber=10000017, FirstName="Ying", MiddleName="Jie", LastName="Xong", SchoolEmail="yingjiex@hawaii.edu", OtherEmail="yingjie@outlook.com", Phone="(459) 210-5241",                     GendersId=32, DegreeProgramsId=18, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2016},
                new Student {Id=18, StudentNumber=10000018, FirstName="Sakura", MiddleName="Noburi", LastName="Ichiyama", SchoolEmail="sakurani@hawaii.edu", OtherEmail="noburi@yahoo.co.jp", Phone="(509) 824-4212",             GendersId=32, DegreeProgramsId=18, TracksId=19, PlansId=29, DegreeStartSemsId=2, DegreeStartYear=2014},
                new Student {Id=19, StudentNumber=10000019, FirstName="Sayuri", MiddleName="Misa", LastName="Katsumoto", SchoolEmail="sayurimk@hawaii.edu", OtherEmail="katsumoto.sayuri@yahoo.co.jp", Phone="(210) 518-8961",    GendersId=32, DegreeProgramsId=17, TracksId=20, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2013},
                new Student {Id=20, StudentNumber=10000020, FirstName="Ton", MiddleName="Ton", LastName="Balatong", SchoolEmail="tontonb@hawaii.edu", OtherEmail="ton2balatong@gmail.com.com", Phone="(329) 283-4822",            GendersId=31, DegreeProgramsId=17, TracksId=20, PlansId=30, DegreeStartSemsId=1, DegreeStartYear=2012},
                new Student {Id=21, StudentNumber=10000021, FirstName="Laura", MiddleName="Windham", LastName="Correa", SchoolEmail="lwcorrea@hawaii.edu", OtherEmail="laura_correa@yahoo.com", Phone="(348) 283-2384",           GendersId=31, DegreeProgramsId=18, TracksId=19, PlansId=29, DegreeStartSemsId=1, DegreeStartYear=2010},
                new Student {Id=22, StudentNumber=10000022, FirstName="Xi", MiddleName="Xang", LastName="Xu", SchoolEmail="xxx@hawaii.edu", OtherEmail="xixangxu@wechat.ch", Phone="(516) 278-5295",                              GendersId=32, DegreeProgramsId=17, TracksId=20, PlansId=30, DegreeStartSemsId=1, DegreeStartYear=2010}
            };
            students.ForEach(s => context.Students.Add(s));
            SaveChanges(context);

            var prevdegree = new List<PrevDegree>
            {
                new PrevDegree {StudentID = 1, DegreeTypesID=22, Title="Biology", CumulativeGPA=3.32M, SchoolName="Ohio State University", Major="Biology", DateOfAward=Convert.ToDateTime("11/12/2009") },
                new PrevDegree {StudentID = 2, DegreeTypesID=24, Title="Agriculture", CumulativeGPA=3.95M, SchoolName="University of Central Florida", Major="Agricultural Sciences", DateOfAward=Convert.ToDateTime("05/17/2017") }
            };
            prevdegree.ForEach(s => context.PreviousDegrees.Add(s));
            SaveChanges(context);

            //var coursework = new List<Coursework>
            //{
            //    new Coursework {StudentID=1,  CourseID=15, GradeID=4},
            //    new Coursework {StudentID=1,  CourseID=26, GradeID=7},
            //    new Coursework {StudentID=1,  CourseID=1,  GradeID=10},
            //    new Coursework {StudentID=1,  CourseID=23, GradeID=8},
            //    new Coursework {StudentID=1,  CourseID=16, GradeID=5},
            //    new Coursework {StudentID=2,  CourseID=20, GradeID=5},
            //    new Coursework {StudentID=2,  CourseID=15, GradeID=7},
            //    new Coursework {StudentID=2, SemestersID=1, Year=2003, CourseID=10, GradeID=4},
            //    new Coursework {StudentID=3, SemestersID=3, Year=2003, CourseID=30, GradeID=9},
            //    new Coursework {StudentID=3, SemestersID=2, Year=2003, CourseID=1,  GradeID=12},
            //    new Coursework {StudentID=3, SemestersID=1, Year=2003, CourseID=15, GradeID=13},
            //    new Coursework {StudentID=3, SemestersID=2, Year=2004, CourseID=31, GradeID=16}


            //};
            //coursework.ForEach(s => context.Coursework.Add(s));
            //SaveChanges(context);


            var races = new List<Races>
            {
                new Races {Id=1, Name="White / Caucasian"},
                new Races {Id=2, Name="Black / African American"},
                new Races {Id=3, Name="Latino / Hispanic"},
                new Races {Id=4, Name="Native Hawaiian" },
                new Races {Id=5, Name="Other Pacific Islander" },
                new Races {Id=6, Name="Native Alaskan"},
                new Races {Id=7, Name="Native American"},
                new Races {Id=8, Name="Chinese" },
                new Races {Id=9, Name="Filipino"},
                new Races {Id=10, Name="Korean"},
                new Races {Id=11, Name="Japanese" },
                new Races {Id=12, Name="Other Asian"},
                new Races {Id=13, Name="Other"}
            };
            races.ForEach(s => context.Races.Add(s));
            SaveChanges(context);

            var personRaces = new List<PersonRaces>
            {
                new PersonRaces {ID=1, StudentID=1, RaceID=3, IsSelectedPR=true},
                new PersonRaces {ID=2, StudentID=1, RaceID=1, IsSelectedPR=true},
                new PersonRaces {ID=3, StudentID=1, RaceID=7, IsSelectedPR=true},
                new PersonRaces {ID=4, StudentID=2, RaceID=10, IsSelectedPR=true},
                new PersonRaces {ID=5, StudentID=3, RaceID=4, IsSelectedPR=true},
                new PersonRaces {ID=6, StudentID=3, RaceID=2, IsSelectedPR=true},
                new PersonRaces {ID=7, StudentID=4, RaceID=12, IsSelectedPR=true},
                new PersonRaces {ID=8, StudentID=5, RaceID=4, IsSelectedPR=true},
                new PersonRaces {ID=9, StudentID=6, RaceID=5, IsSelectedPR=true},
                new PersonRaces {ID=10, StudentID=7, RaceID=6, IsSelectedPR=true},
                new PersonRaces {ID=11, StudentID=8, RaceID=7, IsSelectedPR=true},
                new PersonRaces {ID=12, StudentID=9, RaceID=5, IsSelectedPR=true},
                new PersonRaces {ID=13, StudentID=10, RaceID=1, IsSelectedPR=true},
                new PersonRaces {ID=14, StudentID=11, RaceID=2, IsSelectedPR=true},
                new PersonRaces {ID=15, StudentID=12, RaceID=5, IsSelectedPR=true},
                new PersonRaces {ID=16, StudentID=13, RaceID=7, IsSelectedPR=true},
                new PersonRaces {ID=17, StudentID=14, RaceID=9, IsSelectedPR=true},
                new PersonRaces {ID=18, StudentID=15, RaceID=10, IsSelectedPR=true},
                new PersonRaces {ID=19, StudentID=16, RaceID=11, IsSelectedPR=true},
                new PersonRaces {ID=20, StudentID=17, RaceID=4, IsSelectedPR=true},
                new PersonRaces {ID=21, StudentID=18, RaceID=1, IsSelectedPR=true},
                new PersonRaces {ID=22, StudentID=19, RaceID=12, IsSelectedPR=true},
                new PersonRaces {ID=23, StudentID=20, RaceID=8, IsSelectedPR=true},
                new PersonRaces {ID=24, StudentID=21, RaceID=4, IsSelectedPR=true},
                new PersonRaces {ID=25, StudentID=22, RaceID=8, IsSelectedPR=true}
            };

            races.ForEach(s => context.Races.Add(s));
            SaveChanges(context);

        }


        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

    }
}

