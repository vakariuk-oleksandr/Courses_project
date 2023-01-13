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
    public class DeleteStudyingform : IRequest
    {
        public string Id { get; set; }
    }

    public class DeleteFormHandler : IRequestHandler<DeleteStudyingform>
    {
        private readonly ITeacherDbContext context;

        public DeleteFormHandler(ITeacherDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteStudyingform request, CancellationToken cancellationToken)
        {
            var filter = Builders<Models.domain.Studyingform>.Filter.Eq("Id", request.Id);
            await context.Studyingform.DeleteOneAsync(filter, cancellationToken);
            return Unit.Value;
        }
    }



}

