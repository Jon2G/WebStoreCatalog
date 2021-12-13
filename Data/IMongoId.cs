using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebStore.Data
{
    public interface IMongoId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
