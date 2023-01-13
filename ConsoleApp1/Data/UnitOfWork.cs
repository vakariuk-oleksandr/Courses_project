using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplContext aplContext;

        public UnitOfWork(AplContext aplContext, ICoursesrep coursesrep)
        {
            this.aplContext = aplContext;
            this.coursesrep = coursesrep;
        }
        public ICoursesrep coursesrep { get; }


        public async Task SaveChangesAsync()
        {
            await aplContext.SaveChangesAsync();
        }
    }
}
