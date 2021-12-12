using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebStore.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement ("Name")]
        public string Name { get; set; }
        [BsonElement("Nickname")]
        public string Nickname { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        public User(string Name,string Nickname,string Password)
        {
            
            this.Name = Name;
            this.Nickname = Nickname;
            this.Password = Password;
        }

    }
}
