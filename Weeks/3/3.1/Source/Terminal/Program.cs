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
            IMongoDatabase database = _client.GetDatabase("school");
            IMongoCollection<Item> collection = database.GetCollection<Item>("students");

            List<Item> t = await collection.Find(new BsonDocument()).ToListAsync();

            foreach (Item item in t)
            {
                ScoreItem lowerst = item.Scores.OrderBy(x => x.Score).First(x => x.Type == "homework");
                item.Scores.Remove(lowerst);
                ReplaceOneResult result = await collection.ReplaceOneAsync(x => x.Id == item.Id, item);
            }
        }

        [BsonIgnoreExtraElements]
        private class Item
        {
            public int Id { get; set; }

            [BsonElement("scores")]
            public List<ScoreItem> Scores { get; set; }

            [BsonElement("name")]
            public string Name { get; set; }

            public override string ToString()
            {
                return string.Format("Id: {0}, Scores: {1}", Id, Scores);
            }
        }

        private sealed class ScoreItem
        {
            [BsonElement("type")]
            public string Type { get; set; }

            [BsonElement("score")]
            public double Score { get; set; }
        }
    }
}