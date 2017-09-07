﻿using System;
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
            var students = new List<G_Student>
            {
                new G_Student {Id=1, StudentNumber=10000001, FirstName="Carson", MiddleName="John", LastName="Alexander", SchoolEmail="carsonja@hawaii.edu", OtherEmail="carson_alexander@gmail.com", Phone="(808) 546-2455", DegreeStart=DateTime.Parse("2005-08-22"), DegreeEnd=DateTime.Parse("2007-05-15")},
                new G_Student {Id=2, StudentNumber=10000002, FirstName="Meredith", MiddleName="Mary", LastName="Alonso", SchoolEmail="alonsomm@hawaii.edu", OtherEmail="mereditha@yahoo.com", Phone="(808) 942-3333", DegreeStart=DateTime.Parse("2002-08-25"), DegreeEnd=DateTime.Parse("2004-05-13")},
                new G_Student {Id=3, StudentNumber=10000003, FirstName="Arturo", MiddleName="Javier", LastName="Anand", SchoolEmail="arturoja@hawaii.edu", OtherEmail="anand_arturo@outlook.com", Phone="(919) 546-7562", DegreeStart=DateTime.Parse("2003-08-24"), DegreeEnd=DateTime.Parse("2005-05-10")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

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
                new G_CommonFields {ID=31, Name="White / Caucasian", Category="Race/Ethnicity", DisplayOrder=1 },
                new G_CommonFields {ID=32, Name="Black / African American", Category="Race/Ethnicity", DisplayOrder=2 },
                new G_CommonFields {ID=33, Name="Latino / Hispanic", Category="Race/Ethnicity", DisplayOrder=3 },
                new G_CommonFields {ID=34, Name="Native Hawaiian", Category="Race/Ethnicity", DisplayOrder=4 },
                new G_CommonFields {ID=35, Name="Other Pacific Islander", Category="Race/Ethnicity", DisplayOrder=5 },
                new G_CommonFields {ID=36, Name="Native Alaskan", Category="Race/Ethnicity", DisplayOrder=6 },
                new G_CommonFields {ID=37, Name="Native American", Category="Race/Ethnicity", DisplayOrder=7 },
                new G_CommonFields {ID=38, Name="Chinese", Category="Race/Ethnicity", DisplayOrder=8 },
                new G_CommonFields {ID=39, Name="Filipino", Category="Race/Ethnicity", DisplayOrder=9 },
                new G_CommonFields {ID=40, Name="Korean", Category="Race/Ethnicity", DisplayOrder=10 },
                new G_CommonFields {ID=41, Name="Japanese", Category="Race/Ethnicity", DisplayOrder=11 },
                new G_CommonFields {ID=42, Name="Other Asian", Category="Race/Ethnicity", DisplayOrder=12 },
                new G_CommonFields {ID=43, Name="Other", Category="Race/Ethnicity", DisplayOrder=13 },
                new G_CommonFields {ID=44, Name="Male", Category="Gender", DisplayOrder=1 },
                new G_CommonFields {ID=45, Name="Female", Category="Gender", DisplayOrder=2 }
         
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


            var coursework = new List<G_Coursework>
            {
                new G_Coursework {StudentID=1, SemestersID=1, Year=2005, CourseID=15, Grade=Grade.A},
                new G_Coursework {StudentID=1, SemestersID=2, Year=2006, CourseID=26, Grade=Grade.C},
                new G_Coursework {StudentID=1, SemestersID=1, Year=2006, CourseID=1,  Grade=Grade.B},
                new G_Coursework {StudentID=1, SemestersID=2, Year=2007, CourseID=23, Grade=Grade.B},
                new G_Coursework {StudentID=1, SemestersID=1, Year=2007, CourseID=16, Grade=Grade.F},
                new G_Coursework {StudentID=2, SemestersID=1, Year=2002, CourseID=20, Grade=Grade.F},
                new G_Coursework {StudentID=2, SemestersID=2, Year=2003, CourseID=15},
                new G_Coursework {StudentID=2, SemestersID=1, Year=2003, CourseID=10},
                new G_Coursework {StudentID=3, SemestersID=1, Year=2003, CourseID=30, Grade=Grade.F},
                new G_Coursework {StudentID=3, SemestersID=2, Year=2003, CourseID=1,  Grade=Grade.C},
                new G_Coursework {StudentID=3, SemestersID=1, Year=2003, CourseID=15},
                new G_Coursework {StudentID=3, SemestersID=2, Year=2004, CourseID=31, Grade=Grade.A}


            };
            coursework.ForEach(s => context.Coursework.Add(s));
            context.SaveChanges();

        }

    }
}