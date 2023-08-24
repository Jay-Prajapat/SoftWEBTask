
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.DAL
{
    public class StudentDBEntity:DbContext
    {
        public StudentDBEntity():base("name=StudentDBEntity")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentDBEntity, StudentInformationSystem.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("StudentCourses");
                });
                   
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}