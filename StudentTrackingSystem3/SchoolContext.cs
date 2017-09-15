namespace StudentTrackingSystem3
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=GStudentRecord")
        {
        }

        public virtual DbSet<G_CommonFields> G_CommonFields { get; set; }
        public virtual DbSet<G_Course> G_Course { get; set; }
        public virtual DbSet<G_Coursework> G_Coursework { get; set; }
        public virtual DbSet<G_PersonRaces> G_PersonRaces { get; set; }
        public virtual DbSet<G_PrevDegree> G_PrevDegree { get; set; }
        public virtual DbSet<G_Races> G_Races { get; set; }
        public virtual DbSet<G_Student> G_Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Coursework)
                .WithRequired(e => e.G_CommonFields)
                .HasForeignKey(e => e.SemestersID);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_PrevDegree)
                .WithRequired(e => e.G_CommonFields)
                .HasForeignKey(e => e.DegreeTypeId);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student)
                .WithOptional(e => e.G_CommonFields)
                .HasForeignKey(e => e.ConcentrationsId);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student1)
                .WithOptional(e => e.G_CommonFields1)
                .HasForeignKey(e => e.DegreeProgramsId);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student2)
                .WithOptional(e => e.G_CommonFields2)
                .HasForeignKey(e => e.G_CommonFields_ID);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student3)
                .WithOptional(e => e.G_CommonFields3)
                .HasForeignKey(e => e.G_CommonFields_ID1);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student4)
                .WithOptional(e => e.G_CommonFields4)
                .HasForeignKey(e => e.G_CommonFields_ID2);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student5)
                .WithOptional(e => e.G_CommonFields5)
                .HasForeignKey(e => e.G_CommonFields_ID3);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student6)
                .WithOptional(e => e.G_CommonFields6)
                .HasForeignKey(e => e.GendersId);

            modelBuilder.Entity<G_CommonFields>()
                .HasMany(e => e.G_Student7)
                .WithOptional(e => e.G_CommonFields7)
                .HasForeignKey(e => e.TracksId);

            modelBuilder.Entity<G_Course>()
                .HasMany(e => e.G_Coursework)
                .WithRequired(e => e.G_Course)
                .HasForeignKey(e => e.CourseID);

            modelBuilder.Entity<G_Races>()
                .HasMany(e => e.G_PersonRaces)
                .WithRequired(e => e.G_Races)
                .HasForeignKey(e => e.RaceID);

            modelBuilder.Entity<G_Student>()
                .HasMany(e => e.G_Coursework)
                .WithRequired(e => e.G_Student)
                .HasForeignKey(e => e.StudentID);

            modelBuilder.Entity<G_Student>()
                .HasMany(e => e.G_PersonRaces)
                .WithRequired(e => e.G_Student)
                .HasForeignKey(e => e.StudentID);

            modelBuilder.Entity<G_Student>()
                .HasMany(e => e.G_PrevDegree)
                .WithOptional(e => e.G_Student)
                .HasForeignKey(e => e.Student_Id);
        }
    }
}
