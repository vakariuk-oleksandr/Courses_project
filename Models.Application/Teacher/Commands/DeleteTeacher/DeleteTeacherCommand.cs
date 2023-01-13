using MediatR;
using Models.domain;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Application
{
    public class DeleteTeacherCommand : IRequest
    {
        public string Id { get; set; }
    }

    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
    {
        private readonly ITeacherDbContext context;

        public DeleteTeacherCommandHandler(ITeacherDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var filter = Builders<Teachers>.Filter.Eq("Id", request.Id);
            await context.Teacher.DeleteOneAsync(filter, cancellationToken);
            return Unit.Value;
        }
    }
}
