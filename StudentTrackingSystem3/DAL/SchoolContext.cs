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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}