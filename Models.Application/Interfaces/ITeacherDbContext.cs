using Microsoft.EntityFrameworkCore;
using Models.domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Models.Application
{
    public interface ITeacherDbContext
    {
        public IMongoCollection<Teachers> Teacher { get; }
        public IMongoCollection<Studyingform> Studyingform { get; }
        public IMongoCollection<Specialization> Specialization { get; }
    }
}
