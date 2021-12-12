using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace WebStore.Models
{
    public class PageInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("Mision")]
        public string Mision { get; set; }
        [BsonElement("Vision")]
        public string Vision { get; set; }
        [BsonElement("Target")]
        public string Target { get; set; }

        public PageInfo( string Mision, string Vision, string Target)
        {
            this.Mision = Mision;
            this.Vision = Vision;
            this.Target = Target;
        }
    }
}
