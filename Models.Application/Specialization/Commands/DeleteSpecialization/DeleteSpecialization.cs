using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Application
{
    public class DeleteSpecialization : IRequest
    {
        public string Id { get; set; }
    }

    public class DeleteSpecializationHandler : IRequestHandler<DeleteSpecialization>
    {
        private readonly ITeacherDbContext context;

        public DeleteSpecializationHandler(ITeacherDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteSpecialization request, CancellationToken cancellationToken)
        {
            var filter = Builders<Models.domain.Specialization>.Filter.Eq("Id", request.Id);
            await context.Specialization.DeleteOneAsync(filter, cancellationToken);
            return Unit.Value;
        }
    }
}

