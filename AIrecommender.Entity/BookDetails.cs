using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.Entity
{
    public class BookDetails
    {
        public List<Book> Books { get; set; }= new List<Book>();
        public List<BookUserRating> UserRatings { get; set; }=new List<BookUserRating>();
        public List<User> Users { get; set; } = new List<User>();

        public static explicit operator BookDetails(RedisValue v)
        {
            throw new NotImplementedException();
        }
    }
    public class Book
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
        public string ImageUrlSmall { get; set; }
        public string ImageUrlMedium { get; set; }
        public string ImageUrlLarge { get; set; }
        public List<BookUserRating> UserRatings { get; set; } = new List<BookUserRating>();

    }
    public class BookUserRating
    {
        public int Rating { get; set; }
        public string ISBN { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }

    }
    public class User
    {
        public int UserID { get; set; }
        public int Age { get; set; }
        public string  City{ get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<BookUserRating> UserRatings { get; set; }
    }
}
