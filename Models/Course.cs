using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebStore.Models
{
    public class Course
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
        public Byte[] Image { get; set; }
        [BsonElement("Off")]
        public int Off { get; set; }
        [BsonElement("Assessment")]
        public int Assessment { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }

        public float Disscount => (Price * Off / 100);
        public bool HasDiscount => Off > 0;
        public float FinalPrice => HasDiscount ? Price - Disscount : Price;

        public Course(string Name, float Price, string Description,
            Byte[] Image, int Off, int Assessment, DateTime Date)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.Image = Image;
            this.Off = Off;
            this.Assessment = Assessment;
            this.Date = Date;
        }
    }
}
