using System;
using System.Collections.Generic;
using Axway.Database.ModelConfigurations;
using Axway.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Axway.Database
{
    public class AxwayContext : DbContext
    {
        public AxwayContext() {}

        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.CONNECTION_STRING); // Your connection string here
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
            modelBuilder.Entity<Course>()
                .HasData(new Course
                {
                    Id = 1,
                    CourseName = "C#"
                });
            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    Id = 1,
                    Age = 30,
                    Name = "George"

                });
            modelBuilder.Entity<Grade>()
                .HasData(new Grade()
                {
                    Id = 1,
                    StudentId = 1,
                    GradeValue = "Excellent"
                });
            modelBuilder.Entity<StudentCourse>()
                .HasData(new StudentCourse()
                {
                    CourseId = 1,
                    StudentId = 1
                });
        }
    }
}
