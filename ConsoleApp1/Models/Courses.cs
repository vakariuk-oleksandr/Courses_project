using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Data
{
    public class Courses
    {
        public string CoursesID { get; set; }
        public string NameCourses { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        //  public Guid CoursesID { get; set; }
        // public string NameCourses { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public List<StudCourses> StudCourses { get; set; } = new List<StudCourses>();
    }
}