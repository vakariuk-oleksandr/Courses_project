using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Data
{
    public class StudCourses
    {
        public string Id { get; set; }
        public string CoursesID { get; set; }
        public decimal Grades { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Courses Courses { get; set; }
        public Student Student { get; set; }
    }
}
