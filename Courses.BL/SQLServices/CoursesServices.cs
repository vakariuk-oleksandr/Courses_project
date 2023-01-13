using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Courses.Data;

namespace Courses.BL
{
    public class CoursesServices : ICoursesServices
    {
        private readonly IUnitOfWork Uof;
        protected IMapper Mapper;


        public CoursesServices(IUnitOfWork uof, IMapper mapper)
        {
            Uof = uof;
            Mapper = mapper;
        }

        /*public async Task<Courses> AddCourses(PostCoursesDTO obj)
         {
             Courses loc = Mapper.Map<PostCoursesDTO, Courses>(obj);
             var res = await Uof.Courses.a(loc);
             await Uof.SaveChangesAsync();
             return res;
         }
        */
        public async Task<PostCoursesDTO> GetCoursesById(string CoursesID)
        {
            var res = Mapper.Map<Courses.Data.Courses, PostCoursesDTO>
            (await Uof.coursesrep.GetByIdAsync(CoursesID));
            return res;
        }

        public async Task InsertAsync(PostCoursesDTO request)
        {
            var rating = Mapper.Map<PostCoursesDTO, Courses.Data.Courses>(request);
            await Uof.coursesrep.InsertAsync(rating);
        }

        public async Task<IEnumerable<PostCoursesDTO>> GetAllC()
        {

            var courses = await Uof.coursesrep.GetAsync();
            var res = Mapper.Map<IEnumerable<Courses.Data.Courses>, IEnumerable<PostCoursesDTO>>(courses);
            return res;

        }
        /*
        public async Task<PostCoursesDTO> UpdateCourses(PostCoursesDTO obj)
        {
            Courses location = Mapper.Map<Courses>(obj);
            var res = Mapper.Map<Courses, PostCoursesDTO>
            (await Uof.Courses.u(location));
            await Uof.SaveChangesAsync();
            return res;

        }*/

        public async Task DeleteAsync(string CoursesID)
        {
            await Uof.coursesrep.DeleteAsync(CoursesID);
        }

        /*
        public async Task<IEnumerable<CoursesInUserDTO>> GetByUserId(string userId)
        {
            var courses = await Uof.Courses.GetAllCourseByUserId(userId);
            //var res = Mapper.Map<IEnumerable<Courses>, IEnumerable<PostCoursesDTO>>(courses);
            List<CoursesInUserDTO> coursesInUserDTOs = new();
            foreach (var cinu in courses)
            {
                coursesInUserDTOs.Add(new CoursesInUserDTO() { CoursesID = cinu.CoursesID, studId = userId, Price = cinu.Price, Grades = 70, NameCourses = cinu.NameCourses, Description = cinu.Description });
            }
            return coursesInUserDTOs;
        }

        public async Task AddCourseToUser(CoursesInUserDTO coursesInUserDTO)
        {
            StudCourses studCourses = new() { CoursesID = coursesInUserDTO.CoursesID, Id = coursesInUserDTO.studId, Grades = 70 };
            await Uof.Courses.AddCourseToUser(studCourses);
        }*/
    }
}
