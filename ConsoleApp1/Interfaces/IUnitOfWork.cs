using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data
{
    public interface IUnitOfWork
    {
        ICoursesrep coursesrep { get; }
        Task SaveChangesAsync();
    }
}
