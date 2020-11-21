using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTrackingSystem3.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudentTrackingSystem3.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Coursework> Coursework { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CommonFields> CommonFields { get; set; }
        public DbSet<PrevDegree> PreviousDegrees { get; set; }
        public DbSet<Races> Races { get; set; }
        public DbSet<PersonRaces> PersonRaces { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Graduation> Graduations { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public DbSet<PostGraduation> PostGraduation { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<PreviousEmployment> PreviousEmployment { get; set; }
        public DbSet<Publications> Publications { get; set; }
        public DbSet<Grants> Grants { get; set; }
        public DbSet<Honors> Honors { get; set; }
        public DbSet<Manuscript> Manuscripts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>()
                .HasRequired(c => c.DegreeStartSems)
                .WithMany()
                .HasForeignKey(d => d.DegreeStartSemsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasRequired(c => c.Genders)
                .WithMany()
                .HasForeignKey(d => d.GendersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasRequired(c => c.DegreePrograms)
                .WithMany()
                .HasForeignKey(d => d.DegreeProgramsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasRequired(c => c.Tracks)
                .WithMany()
                .HasForeignKey(d => d.TracksId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasRequired(c => c.Plans)
                .WithMany()
                .HasForeignKey(d => d.PlansId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coursework>()
               /*.HasRequired(c => c.Semesters)
               .WithMany()
               .HasForeignKey(d => d.SemestersID)
               .WillCascadeOnDelete(false)*/;

            modelBuilder.Entity<PreviousEmployment>()
                .HasRequired(c => c.StartMonth)
                .WithMany()
                .HasForeignKey(d => d.StartMonthId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publications>()
                .HasRequired(c => c.PubMonth)
                .WithMany()
                .HasForeignKey(d => d.PubMonthId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grants>()
                .HasRequired(c => c.GrantMonth)
                .WithMany()
                .HasForeignKey(d => d.GrantMonthId)
                .WillCascadeOnDelete(false);

            /*****/
            //modelBuilder.Entity<Performance>()
            //     .HasRequired(c => c.Student)
            //     .WithMany()
            //     .HasForeignKey(d => d.StudentID)
            //     .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PostGraduation>()
            //    .HasRequired(c => c.Student)
            //    .WithMany()
            //    .HasForeignKey(d => d.StudentID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PrevDegree>()
            //    .HasRequired(c => c.Student)
            //    .WithMany()
            //    .HasForeignKey(d => d.StudentID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PreviousEmployment>()
            //    .HasRequired(c => c.Student)
            //    .WithMany()
            //    .HasForeignKey(d => d.StudentID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Coursework>()
            //    .HasRequired(c => c.Student)
            //    .WithMany()
            //    .HasForeignKey(d => d.StudentID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Honors>()
            //    .HasRequired(c => c.Student)
            //    .WithMany()
            //    .HasForeignKey(d => d.StudentID)
            //    .WillCascadeOnDelete(false);
           /*****/

            //modelBuilder.Entity<G_File>()
            //    .HasRequired(c => c.Manuscript)
            //    .WithMany()
            //    .HasForeignKey(d => d.ManuscriptID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<G_File>()
            //    .HasRequired(c => c.CurriculumVitae)
            //    .WithMany()
            //    .HasForeignKey(d => d.CurriculumVitaeID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<G_File>()
            //    .HasRequired(c => c.Activity)
            //    .WithMany()
            //    .HasForeignKey(d => d.ActivityID)
            //    .WillCascadeOnDelete(false);

        }




    }
}