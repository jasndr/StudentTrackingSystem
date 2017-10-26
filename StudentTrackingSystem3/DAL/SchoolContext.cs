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
        public DbSet<G_Student> Students { get; set; }
        public DbSet<G_Coursework> Coursework { get; set; }
        public DbSet<G_Course> Courses { get; set; }
        public DbSet<G_CommonFields> CommonFields { get; set; }
        public DbSet<G_PrevDegree> PreviousDegrees { get; set; }
        public DbSet<G_Races> Races { get; set; }
        public DbSet<G_PersonRaces> PersonRaces { get; set; }
        public DbSet<G_Activity> Activities { get; set; }
        public DbSet<G_Performance> Performances { get; set; }
        public DbSet<G_File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<G_Student>()
                .HasRequired(c => c.DegreeStartSems)
                .WithMany()
                .HasForeignKey(d => d.DegreeStartSemsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<G_Student>()
                .HasRequired(c => c.Genders)
                .WithMany()
                .HasForeignKey(d => d.GendersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<G_Student>()
                .HasRequired(c => c.Concentrations)
                .WithMany()
                .HasForeignKey(d => d.ConcentrationsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<G_Student>()
                .HasRequired(c => c.Tracks)
                .WithMany()
                .HasForeignKey(d => d.TracksId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<G_Student>()
                .HasRequired(c => c.Plans)
                .WithMany()
                .HasForeignKey(d => d.PlansId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<G_Coursework>()
               .HasRequired(c => c.Semesters)
               .WithMany()
               .HasForeignKey(d => d.SemestersID)
               .WillCascadeOnDelete(false);

        }
    }
}