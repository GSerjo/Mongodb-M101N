using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Terminal
{
    internal class Program
    {
        private static readonly MongoClient _client = new MongoClient();

        private static void Main()
        {
            try
            {
                Do().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }

        private static async Task Do()
        {
            IMongoDatabase database = _client.GetDatabase("students");
            IMongoCollection<Item> collection = database.GetCollection<Item>("grades");

            List<Item> items = await collection.Find(Builders<Item>.Filter.Eq("type", "homework"))
                .Sort(Builders<Item>.Sort.Ascending("student_id").Ascending("score"))
                .ToListAsync();

            List<ObjectId> ids = items.GroupBy(x => x.StudentId).Select(item => item.First().Id).ToList();

            DeleteResult result = await collection.DeleteManyAsync(Builders<Item>.Filter.In(x => x.Id, ids));
        }

        [BsonIgnoreExtraElements]
        private class Item
        {
            public ObjectId Id { get; set; }

            [BsonElement("score")]
            public double Score { get; set; }

            [BsonElement("student_id")]
            public int StudentId { get; set; }


            public override string ToString()
            {
                return string.Format("Id: {0}, Score: {1}, StudentId: {2}", Id, Score, StudentId);
            }
        }
    }
}