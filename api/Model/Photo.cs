using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace api.Model
{
    public class Photo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ImageName")]
        public required string ImageName { get; set; }

        [BsonElement("FullPath")]
        public required string FullPath { get; set; }

        [BsonElement("Extension")]
        public required string Extension { get; set; }
    }
}
