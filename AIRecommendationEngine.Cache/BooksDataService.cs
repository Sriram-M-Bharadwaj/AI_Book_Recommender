using AIRecommender.Data_Loader;
using AIRecommender.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Cache
{
    public class BooksDataService
    {
        public BookDetails GetBookDetails()
        {
            IDataCacher cache = new MemDataCacher();
            if (cache.GetData() == null)
            {
                DataLoaderFactory factory = DataLoaderFactory.Instance;
                IDataLoader loader = factory.GetDataLoader();
                BookDetails details = loader.Load();
                cache.SetData(details);
                return details;
            }
            else
            {
                return cache.GetData();
            }
           
        }
    }
}
