using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses_project.EventAutoBus
{
    public class IntegrationBaseEvent
    {
        public string Id { get; set; }
        public DateTime TriggeredAt { get; } = DateTime.UtcNow;
    }
}
