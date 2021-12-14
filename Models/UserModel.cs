using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Data;

namespace WebStore.Models
{
    [Table("Users")]
    public class UserModel : IMongoId
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

        public UserModel()
        {

        }
        public UserModel(string Name,string Nickname,string Password)
        {
            
            this.Name = Name;
            this.Nickname = Nickname;
            this.Password = Password;
        }
        public Task<UserModel> Save(MongoDb db)
        {
            return db.Save(this);
        }
        public async Task<bool> Find(MongoDb db)
		{
            return db.GetUser(this);
		}
    }
}
