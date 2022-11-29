using MongoDB.Bson.Serialization.Attributes;

namespace ApiMS.Model
{
    public class Product : Entity
    {

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
