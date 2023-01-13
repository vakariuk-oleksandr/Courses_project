using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

using Models.domain;
using Models.Application;
using Courses.Persistence;

namespace Course.Persistence
{
    public class TeacherDbContext : ITeacherDbContext
    {
        private readonly IMongoClient client;
        private IMongoDatabase database;

        public TeacherDbContext()
        {
            var pack = new ConventionPack
          {
            new StringObjectIdConvention()
          };
            ConventionRegistry.Register("MongoObjectIdParsingConventions", pack, _ => true);
            client = new MongoClient(DBSettigns.ConnenctionString);
            database = client.GetDatabase(DBSettigns.DatabaseName);
        }

        public IMongoCollection<Teachers> Teacher { get => database.GetCollection<Teachers>(Collections.Teacher); }
        public IMongoCollection<Specialization> Specialization { get => database.GetCollection<Specialization>(Collections.Specialization); }
        public IMongoCollection<Studyingform> Studyingform { get => database.GetCollection<Studyingform>(Collections.Studyingform); }

        private class StringObjectIdConvention : ConventionBase, IPostProcessingConvention
        {
            public void PostProcess(BsonClassMap classMap)
            {
                var idMap = classMap.IdMemberMap;
                if (idMap != null && idMap.MemberName == "Id" && idMap.MemberType == typeof(string))
                {
                    idMap.SetIdGenerator(new StringObjectIdGenerator());
                }
            }
        }


    }
}
