using AIrecommender.Entity;
using AIRecommender.CoreEngine;
using AIRecommender.Data_Loader;
using AIRecommender.DataAggregator;
using AIRecommender.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using AIRecommender.Cache;
//using AIRecommendationEngine.Cache;


namespace AIRecommender.AIRecommenderEngine
{
    public class RecommendationEngine
    {
        public IList<Book> Recommend(Preference preference, int limit)            
        {

            

            List<Book> books = new List<Book>();
          BooksDataService service = new BooksDataService();


           BookDetails details = service.GetBookDetails();

            //BookDetails details = new CSVDataLoader().Load();

            Dictionary<string, List<int>> aggregate = new RatingsAggregator().Aggregate(details, preference);
            foreach(var book in details.UserRatings)
            {
                if (book.ISBN == preference.ISBN)
                {
                    if (aggregate.ContainsKey(preference.ISBN))
                    {
                        aggregate[preference.ISBN].Add(book.Rating);
                    }
                    else
                    {
                        aggregate.Add(preference.ISBN, new List<int>());
                        aggregate[preference.ISBN].Add(book.Rating);
                    }
                   
                    
                }
            }

            Dictionary<string, List<int>> baseData =new Dictionary<string,List<int>>();
           Dictionary<string, List<int>> otherData = new Dictionary<string, List<int>>();
            IRecommender pearsonRecommender = new PersonRecommender();

            foreach (var item in aggregate.Keys)
            {
                if (item == preference.ISBN)
                {
                    baseData[item] = aggregate[item];

                }
                else
                {
                    otherData[item] = aggregate[item];
                }
            }

            Dictionary<string, double> pearsonResult = new Dictionary<string, double>();
            if(aggregate.ContainsKey(preference.ISBN))
            {
                foreach (var item in otherData)
                {
                    double val = pearsonRecommender.GetCorrelation(aggregate[preference.ISBN].ToArray(), item.Value.ToArray());

                    pearsonResult[item.Key] = val;
                }
            }
           else
            {
                //Console.WriteLine("not found - Printed at line 54 Recommendation Engine");
            }

            List<string> recommendedBooks = pearsonResult.OrderByDescending(record => record.Value).Select(record=>record.Key).Take(limit).ToList();
            
            //var sortedDict =(from entry in pearsonResult orderby entry.Key descending select entry).ToList();

           
 
            foreach (var item in recommendedBooks)
            {
                
                foreach (var book in details.Books)
                {
                    
                    if (book.ISBN==item)
                    {
                       
                        books.Add(book);
                    }
                }
            }
       


            return books;
        }
    }
}
