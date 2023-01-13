using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Courses.BL
{
    public interface ICoursesServices
    {
        // Task<PostCoursesDTO> UpdateCourses(PostCoursesDTO obj);// update courses
        Task<PostCoursesDTO> GetCoursesById(string id);// return courses by courses id
        Task DeleteAsync(string id);// delete courses by courses id
        Task<IEnumerable<PostCoursesDTO>> GetAllC();// return all courses
        Task InsertAsync(PostCoursesDTO request);

        //  Task<IEnumerable<CoursesInUserDTO>> GetByUserId(string userId);

        //  Task AddCourseToUser(CoursesInUserDTO coursesInUserDTO);
    }
}
