using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using WebStore.Models;

namespace WebStore.Data
{
    public class MongoDb
    {
        private const string ConnectionString = "mongodb://25.18.25.69:27017,25.17.54.167:27017,25.17.178.128:27017";
        private const string DbName = "CoursesDb";
        private readonly IMongoDatabase _database;
        public MongoDb()
        {
            MongoClient client = new(ConnectionString);
            _database = client.GetDatabase(DbName);
        }

        private string GetTableName<T>()
        {
            Type type = typeof(T);
            TableAttribute? table = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute))!;
            return table.Name;
        }

        public async Task<T> Save<T>(T obj) where T : IMongoId
        {
            await Task.Yield();
            string tableName = GetTableName<T>();
            IMongoCollection<T> collection = this._database.GetCollection<T>(tableName);
            if (string.IsNullOrEmpty(obj.Id))
                obj.Id = ObjectId.GenerateNewId().ToString();
            var result = await collection.ReplaceOneAsync(d => d.Id == obj.Id, obj, new ReplaceOptions() { IsUpsert = true });
            return obj;
        }

        public async Task<List<T>> GetAllAsync<T>() where T : IMongoId
        {
            IMongoCollection<T> collection = GetCollection<T>();
            return await collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }
        public IMongoCollection<T> GetCollection<T>() where T : IMongoId
        {
            return this._database.GetCollection<T>(GetTableName<T>());
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : IMongoId
        {
            IFindFluent<T, T> result = GetCollection<T>().Find(predicate);
            return result.FirstOrDefault();
        }
    }
}
