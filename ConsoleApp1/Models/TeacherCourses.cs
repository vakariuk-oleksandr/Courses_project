using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Data
{
    public class TeacherCourses
    {
        public string Id { get; set; }
        public string TeacherID { get; set; }
        public int CoursesID { get; set; }
        public Courses Courses { get; set; }

    }
}