using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebStore.Data;

namespace WebStore.Models
{
    [Table("Courses")]
    public class Course : IMongoId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Price")]
        public float Price { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Image")]
        public byte[] Image { get; set; }
        [BsonElement("Off")]
        public int Off { get; set; }
        [BsonElement("Assessment")]
        public int Assessment { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonIgnore]
        public float Disscount => (Price * Off / 100);
        [BsonIgnore]
        public bool HasDiscount => Off > 0;
        [BsonIgnore]
        public float FinalPrice => HasDiscount ? Price - Disscount : Price;
        [BsonIgnore]
        public bool IsFree => FinalPrice == 0;

        public Course()
        {
            Date=DateTime.Today;
        }
        public Course(string Name, float Price, string Description,
            byte[] Image, int Off, int Assessment, DateTime Date)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.Image = Image;
            this.Off = Off;
            this.Assessment = Assessment;
            this.Date = Date;
        }

        public static async Task<List<Course>> GetAll(MongoDb db)
        {
            return await db.GetAllAsync<Course>();
        }

        public Task<Course> Save(MongoDb db)
        {
            return db.Save(this);
        }

        public bool Validate(out string[] errors)
        {
            List<string> internalErrors = new List<string>();
            if (string.IsNullOrEmpty(Name?.Trim()))
            {
                internalErrors.Add("El nombre no debe estar vacío");
            }

            if (string.IsNullOrEmpty(Description?.Trim()))
            {
                internalErrors.Add("La descripción no debe estar vacía");
            }

            if (Price < 0)
            {
                internalErrors.Add("El precio no debe tener un valor negativo");
            }

            if (Off > 100)
            {
                internalErrors.Add("El descuento no puede ser mayor al 100%");
            }
            errors = internalErrors.ToArray();
            return !errors.Any();
        }
    }
}
