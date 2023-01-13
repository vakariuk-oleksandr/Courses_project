using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Models.Application
{

    public class GetAllTeachersQuery : IRequest<List<TeacherVm>>
    {
    }
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherVm>>
    {
        private readonly ITeacherDbContext context;
        private readonly IMapper mapper;

        public GetAllTeachersQueryHandler(ITeacherDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<List<TeacherVm>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var data = context.Teacher.AsQueryable();
            var ads = new List<TeacherVm>();
            foreach (var item in data)
            {
                ads.Add(mapper.Map<TeacherVm>(item));
            }
            return Task.Run(() => ads);
        }
    }

}