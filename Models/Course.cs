using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebStore.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Cost")]
        public float Cost { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Image")]
        public Byte[] Image { get; set; }
        [BsonElement("Off")]
        public int Off { get; set; }
        [BsonElement("Assessment")]
        public float Assessment { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }

        public Course(string Name,float Cost, string Description,
            Byte[] Image, int Off, float Assessment,DateTime Date)
        {
            this.Name = Name;   
            this.Cost = Cost;
            this.Description = Description;
            this.Image = Image;
            this.Off = Off;
            this.Assessment = Assessment;
            this.Date = Date;
        }
    }
}
