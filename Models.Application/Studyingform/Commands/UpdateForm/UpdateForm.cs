using MediatR;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Models.Application
{
    public class UpdateForm : IRequest<string>
    {
        public string Id { get; set; }
        public string Form { get; set; }
        public string TeacherId { get; set; }
        public string StudentId { get; set; }
    }

    public class UpdateFormHandler : IRequestHandler<UpdateForm, string>
    {
        private readonly ITeacherDbContext context;
        public UpdateFormHandler(ITeacherDbContext context) => this.context = context;


        public async Task<string> Handle(UpdateForm request, CancellationToken cancellationToken)
        {
            Models.domain.Studyingform form;

            var filter = Builders<Models.domain.Studyingform>.Filter.Eq("Id", request.Id);
            form = context.Studyingform.Find(filter).FirstOrDefault();

            if (!(form == null))
            {
                var update = Builders<Models.domain.Studyingform>.Update
                    .Set(a => a.Form, request.Form)
                    .Set(a => a.TeacherId, request.TeacherId)
                    .Set(a => a.StudentId, request.StudentId);
                await context.Studyingform.UpdateOneAsync(filter, update);
                return form.Id;
            }
            else
            {
                form = new Models.domain.Studyingform();
                form.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                form.Form = request.Form;
                form.TeacherId = request.TeacherId;
                form.StudentId = request.StudentId;
                await context.Studyingform.InsertOneAsync(form);
                return form.Id;
            }
        }
    }
}
