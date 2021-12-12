using MongoDB.Driver;

namespace WebStore.Models
{
    public class MongoConect
    {
        public MongoConect()
        {
            MongoClient client = new("mongodb://localhost:27017");
            var database = client.GetDatabase("Catalogo");
        }
       
    }
}
