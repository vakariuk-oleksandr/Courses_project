using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Courses.Data
{
    public interface ICoursesrep
    {
        Task<IEnumerable<Courses>> GetAsync();
        Task<Courses> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task<IEnumerable<Courses>> GetCoursesFromUserAsync(string userId);
        Task InsertAsync(Courses rating);

        // Task<Courses> GetCoursesWithStudent(int CoursID);
        // public Task<IEnumerable<Courses>> AllC();

        // public Task<IEnumerable<Courses>> GetAllCourseByUserId(string userId);

        // public Task AddCourseToUser(StudCourses studCourses);


    }
}