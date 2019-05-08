using System;
using System.Collections.Generic;
using System.Text;
using Axway.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Axway.Database.ModelCongifuration
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(e => new 
            {
                e.CourseId,
                e.StudentId
               
            });
            builder.HasOne(s => s.Student)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Course)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(s => s.CourseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
