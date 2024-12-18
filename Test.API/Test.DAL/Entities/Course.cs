using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DAL.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } // Add this line
    }

}
