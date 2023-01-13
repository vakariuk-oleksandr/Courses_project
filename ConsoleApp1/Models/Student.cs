using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data
{
    public class Student
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string City { get; set; }
        public DateTime Birthdate { get; set; }
        public string Teachingtype { get; set; }
        public string StudyingformID { get; set; }
        public List<Courses> Courses { get; set; } = new List<Courses>();
        public List<StudCourses> StudCourses { get; set; } = new List<StudCourses>();
    }
}
