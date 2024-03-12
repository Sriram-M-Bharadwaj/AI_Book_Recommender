using AIRecommender.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;
using ServiceStack.Redis;

namespace AIRecommender.Cache
{
   public class RedisCache : IDataCacher
    {
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        IDatabase db= redis.GetDatabase();
       //private static readonly RedisClient redisClient = new RedisClient("localhost");
        public BookDetails GetData()
        {
            if (!db.KeyExists("data6"))
            {
                return null;
            }
            
            BookDetails bookDetails = JsonConvert.DeserializeObject<BookDetails>(db.StringGet("data"));
            return bookDetails;       
             
        }
        public void SetData(BookDetails bookDetails)
        {
            
            string obj= JsonConvert.SerializeObject(bookDetails);
            db.StringSet("data6", obj);
        }
    }
}
