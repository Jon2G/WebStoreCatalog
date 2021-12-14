using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Data;

namespace WebStore.Models
{
    [Table("Info")]
    public class InfoPageModel : IMongoId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Mision")]
        public string Mision { get; set; }
        [BsonElement("Vision")]
        public string Vision { get; set; }
        [BsonElement("Target")]
        public string Target { get; set; }
        public InfoPageModel()
        {

        }
        public InfoPageModel(string Mision, string Vision, string Target)
        {
            this.Mision = Mision;
            this.Vision = Vision;
            this.Target = Target;
        }
        public Task<InfoPageModel> Save(MongoDb db) => db.Save(this);
        public static InfoPageModel Get()
        {
            var db = new MongoDb();
            return db.Find<InfoPageModel>(x => true) ?? new InfoPageModel();
        }

        public bool Validate(out string[] errors)
        {
            List<string> internalErrors = new List<string>();
            if (string.IsNullOrEmpty(Mision?.Trim()))
            {
                internalErrors.Add("La mision no debe estar vacío");
            }

            if (string.IsNullOrEmpty(Vision?.Trim()))
            {
                internalErrors.Add("La vision no debe estar vacía");
            }
            if (string.IsNullOrEmpty(Target?.Trim()))
            {
                internalErrors.Add("El objetivo no debe estar vacío");
            }
            errors = internalErrors.ToArray();
            return !errors.Any();
        }
    }
}
