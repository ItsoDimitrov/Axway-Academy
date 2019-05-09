using System;
using System.Collections.Generic;
using System.Text;

namespace Axway.Database.Models
{
    public class Course
    {

        public Course()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
        }
        
        public int Id { get; set; }
        public string CourseName { get; set; }
        
       

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
