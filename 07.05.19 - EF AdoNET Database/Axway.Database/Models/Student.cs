using System;
using System.Collections.Generic;
using System.Text;

namespace Axway.Database.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
            this.Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
