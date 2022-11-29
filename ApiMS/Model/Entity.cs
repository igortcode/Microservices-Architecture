using MongoDB.Bson.Serialization.Attributes;

namespace ApiMS.Model
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
