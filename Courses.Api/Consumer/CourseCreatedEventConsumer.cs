using AutoMapper;
using Courses.Data;
using Courses_project.EventAutoBus;
//using Main_Project.Data;
using MassTransit;
using System.Threading.Tasks;

namespace Courses.Api
{
    public class CourseCreatedEventConsumer : IConsumer<CoursesCreatedEvent>
    {
        private readonly AplContext _dbContext;
        private readonly IMapper _mapper;

        public CourseCreatedEventConsumer(AplContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CoursesCreatedEvent> context)
        {
            var userProfile = _mapper.Map<Courses.Data.Courses>(context.Message);
            _dbContext.Courses.Add(userProfile);
            await _dbContext.SaveChangesAsync();
        }
    }
}
