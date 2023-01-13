using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Models.domain
{
    public class Teachers
    {
        [BsonId]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string SpecializationID { get; set; }
        public string Phonenumb { get; set; }
        // public Specialization specialization { get; set; } //navigations
        // public Studyingform studyingform { get; set; }
        // public List<Courses> Courses { get; set; } = new List<Courses>();
    }
}
