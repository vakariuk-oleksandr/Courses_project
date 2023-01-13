using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Models.domain
{
    public class Specialization
    {
        [BsonId]
        public string SpecializationID { get; set; }
        public string Predmetna_obl { get; set; }
        public string TeachersID { get; set; }

    }
}
