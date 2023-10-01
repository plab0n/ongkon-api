using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations.ElementNameValidators;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Database
{
    public class MongoDbClient : IDbClient
    {
        private MongoClient _mongoClient;

        public MongoDbClient()
        {
            Connect();
        }

        private void Connect()
        {
            var conenctionString = "mongodb://localhost:27017";
            _mongoClient = new MongoClient(conenctionString);
        }

        public Task GetAll<T>(string db)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetItemByQuery<T>(IQuery query)
        {
            var filter = query.GetMongoQuery();
            var bsonDocument = await _mongoClient.GetDatabase("db").GetCollection<BsonDocument>(typeof(T).Name.ToLower()).FindAsync(filter);
            return BsonSerializer.Deserialize<T>(bsonDocument.ToJson());
        }

        public Task GetById<T>(string db, string id)
        {
            throw new NotImplementedException();
        }

        public async Task Save<T>(string db, IRepository item)
        {
            var x = item.GetId();
            var collection = _mongoClient.GetDatabase(db).GetCollection<BsonDocument>(typeof(T).Name.ToLower());
            var newItem = item.ToBsonDocument();
            if (newItem.Contains("_id"))
                newItem.Remove("_id");
            newItem.Add("_id", x);
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", x);
            await collection.ReplaceOneAsync(filter, newItem, new ReplaceOptions { IsUpsert = true });
        }
    }
}
