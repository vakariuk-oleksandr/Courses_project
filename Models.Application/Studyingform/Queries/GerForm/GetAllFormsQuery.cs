using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Models.Application
{

    public class GetAllFormsQuery : IRequest<List<FormVm>>
    {
    }
    public class GetAllFormsQueryHandler : IRequestHandler<GetAllFormsQuery, List<FormVm>>
    {
        private readonly ITeacherDbContext context;
        private readonly IMapper mapper;

        public GetAllFormsQueryHandler(ITeacherDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<List<FormVm>> Handle(GetAllFormsQuery request, CancellationToken cancellationToken)
        {
            var data = context.Studyingform.AsQueryable();
            var ads = new List<FormVm>();
            foreach (var item in data)
            {
                ads.Add(mapper.Map<FormVm>(item));
            }
            return Task.Run(() => ads);
        }
    }

}