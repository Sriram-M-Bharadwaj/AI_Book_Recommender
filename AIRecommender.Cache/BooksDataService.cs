using AIRecommender.Data_Loader;
using AIRecommender.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.Cache
{
    public class BooksDataService
    {
        public BookDetails GetBookDetails()
        {
            IDataCacher cache = new RedisCache();
            if (cache.GetData() == null)
            {
                Console.WriteLine("Loading from file");
                DataLoaderFactory factory = DataLoaderFactory.Instance;
                IDataLoader loader = factory.GetDataLoader();
                BookDetails details = loader.Load();
                cache.SetData(details);
                return details;
            }
            else
            {
                Console.WriteLine("Loading from cache");
                return cache.GetData();
            }

        }
    }
}
