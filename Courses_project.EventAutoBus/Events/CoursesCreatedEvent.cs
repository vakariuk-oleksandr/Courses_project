using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses_project.EventAutoBus
{
    public class CoursesCreatedEvent : IntegrationBaseEvent
    {
        public string NameCourses { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
