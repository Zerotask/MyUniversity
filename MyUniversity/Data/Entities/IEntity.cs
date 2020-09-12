using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyUniversity.Data.Entities
{
    public interface IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
    }
}