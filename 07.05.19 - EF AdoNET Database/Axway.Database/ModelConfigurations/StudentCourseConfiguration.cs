using System;
using System.Collections.Generic;
using System.Text;
using Axway.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Axway.Database.ModelConfigurations
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => new
            {
                sc.CourseId,
                sc.StudentId
            });
        }
    }
}
