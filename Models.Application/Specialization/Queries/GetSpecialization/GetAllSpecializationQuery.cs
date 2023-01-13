using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Models.Application
{

    public class GetAllSpecializationQuery : IRequest<List<SpecializationVm>>
    {
    }
    public class GetAllSpecializationQueryHandler : IRequestHandler<GetAllSpecializationQuery, List<SpecializationVm>>
    {
        private readonly ITeacherDbContext context;
        private readonly IMapper mapper;

        public GetAllSpecializationQueryHandler(ITeacherDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<List<SpecializationVm>> Handle(GetAllSpecializationQuery request, CancellationToken cancellationToken)
        {
            var data = context.Specialization.AsQueryable();
            var ads = new List<SpecializationVm>();
            foreach (var item in data)
            {
                ads.Add(mapper.Map<SpecializationVm>(item));
            }
            return Task.Run(() => ads);
        }
    }

}