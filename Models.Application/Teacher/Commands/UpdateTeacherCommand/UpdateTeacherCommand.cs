using MediatR;
using Models.domain;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Models.Application
{
    public class UpdateTeacherCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string SpecializationID { get; set; }
        public string Phonenumb { get; set; }
    }

    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, string>
    {
        private readonly ITeacherDbContext context;
        public UpdateTeacherCommandHandler(ITeacherDbContext context) => this.context = context;


        public async Task<string> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teachers teacher;

            var filter = Builders<Teachers>.Filter.Eq("Id", request.Id);
            teacher = context.Teacher.Find(filter).FirstOrDefault();

            if (!(teacher == null))
            {
                var update = Builders<Teachers>.Update
                    .Set(a => a.FullName, request.FullName)
                    .Set(a => a.City, request.City)
                    .Set(a => a.Phonenumb, request.Phonenumb);
                await context.Teacher.UpdateOneAsync(filter, update);
                return teacher.Id;
            }
            else
            {
                teacher = new Teachers();
                teacher.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                teacher.FullName = request.FullName;
                teacher.City = request.City;
                teacher.Phonenumb = request.Phonenumb;

                await context.Teacher.InsertOneAsync(teacher);
                return teacher.Id;
            }
        }
    }
}
