using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.BL.DTO
{
    public class CoursesInUserDTO
    {
        public int CoursesID { get; set; }
        public string studId { get; set; }
        public string NameCourses { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Grades { get; set; }

    }
}
