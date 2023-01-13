using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace Models.domain
{
    public class Studyingform
    {
        [BsonId]
        public string Id { get; set; }
        public string Form { get; set; }
        public string TeacherId { get; set; }
        public string StudentId { get; set; }
    }
}
