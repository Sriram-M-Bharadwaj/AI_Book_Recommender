using AIrecommender.Entity;
 
using AIRecommender.AIRecommenderEngine;
 
using AIRecommender.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            RecommendationEngine engine = new RecommendationEngine();
            Preference preference = new Preference { Age = 18, ISBN = "087113375X", State = "new york" };
            List<Book> books=  (List<Book>) engine.Recommend(preference, 10 );
            foreach (Book book in books)
            {
                Console.WriteLine(book.ISBN+" "+book.BookTitle);
            }
             
            Console.WriteLine("finished");
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
