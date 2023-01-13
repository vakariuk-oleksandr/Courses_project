using MediatR;
using Models.domain;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Models.Application
{
    public class UpdateSpecialization : IRequest<string>
    {
        public string SpecializationID { get; set; }
        public string Predmetna_obl { get; set; }
        public string TeachersID { get; set; }
    }

    public class UpdateSpecializationHandler : IRequestHandler<UpdateSpecialization, string>
    {
        private readonly ITeacherDbContext context;
        public UpdateSpecializationHandler(ITeacherDbContext context) => this.context = context;


        public async Task<string> Handle(UpdateSpecialization request, CancellationToken cancellationToken)
        {
            Models.domain.Specialization form;

            var filter = Builders<Models.domain.Specialization>.Filter.Eq("Id", request.SpecializationID);
            form = context.Specialization.Find(filter).FirstOrDefault();

            if (!(form == null))
            {
                var update = Builders<Models.domain.Specialization>.Update
                    .Set(a => a.Predmetna_obl, request.Predmetna_obl);
                await context.Specialization.UpdateOneAsync(filter, update);
                return form.SpecializationID;
            }
            else
            {
                form = new Models.domain.Specialization();
                form.SpecializationID = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                form.Predmetna_obl = request.Predmetna_obl;
                form.TeachersID = request.TeachersID;
                await context.Specialization.InsertOneAsync(form);
                return form.SpecializationID;
            }
        }
    }
}
