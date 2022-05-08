using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace User.API.Entities
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("companyName")]
        public string CompanyName { get; set; }
        [BsonElement("imageFile")]
        public string ImageFile { get; set; }
    }
}
