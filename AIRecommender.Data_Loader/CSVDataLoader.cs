using AIRecommender.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.Data_Loader
{
    public class CSVDataLoader : IDataLoader
    {

        string booksFile = "C:\\Users\\Sriram M B\\Downloads\\BX-CSV-Dump\\BX-Books.csv";
        string usersFile = "C:\\Users\\Sriram M B\\Downloads\\BX-CSV-Dump\\BX-Users.csv";
        string ratingsFile = "C:\\Users\\Sriram M B\\Downloads\\BX-CSV-Dump\\BX-Book-Ratings.csv";
        BookDetails bookDetails = new BookDetails();
        public BookDetails Load()
        {
            //LoadBooks();
            //LoadRatings();
            //LoadUsers();


            Parallel.Invoke(LoadBooks,LoadRatings,LoadUsers);
          
                        
           
            return bookDetails;

        }
        public void LoadRatings()
        {
            StreamReader ratingReader = new StreamReader(ratingsFile);
            ratingReader.ReadLine();

            using (ratingReader)
            {
                while (!ratingReader.EndOfStream)
                {
                    string[] str = ratingReader.ReadLine().Split(';');
                    int uid = int.Parse(str[0].Trim('"'));
                    str[1] = str[1].Trim('"');

                    int rating = int.Parse(str[2].Trim('"'));

                    bookDetails.UserRatings.Add(new BookUserRating { UserId = uid, ISBN = str[1], Rating = rating });


                }

            }
        }
        public void LoadBooks()
        {

            StreamReader booksReader = new StreamReader(booksFile);
            booksReader.ReadLine();
            using (booksReader)
            {
                while (!booksReader.EndOfStream)
                {
                    string delimiter = "\";\"";
                    string[] str = booksReader.ReadLine().Split(new[] { delimiter }, StringSplitOptions.None);


                    int yop = int.Parse(str[3]);
                    str[0] = str[0].Substring(1);



                    bookDetails.Books.Add(new Book
                    {
                        ISBN = str[0],
                        BookTitle = str[1],
                        BookAuthor = str[2],
                        YearOfPublication = yop,
                        Publisher = str[4],
                        ImageUrlSmall = str[5],
                        ImageUrlMedium = str[6],
                        ImageUrlLarge = str[7]
                    });

                }
            }
        }
        public void LoadUsers()
        {

            StreamReader userReader = new StreamReader(usersFile);

            using (userReader)
            {

                userReader.ReadLine();

                while (!userReader.EndOfStream)
                {
                    string line3 = userReader.ReadLine();


                    string delimiter = "\";";

                    string[] parts3 = line3.Split(new[] { delimiter }, StringSplitOptions.None);
                    parts3[0] = parts3[0].Substring(1);
                    parts3[1] = parts3[1].Substring(1);


                    User user = new User();

                    user.UserID = int.Parse(parts3[0]);

                    string loc = parts3[1];

                    List<string> locparts = loc.Split(',').Select(s => s.Trim(' ')).ToList();

                    user.City = locparts.Count >= 1 ? locparts[0] : "";
                    user.State = locparts.Count >= 2 ? locparts[1] : "";
                    user.Country = locparts.Count >= 3 ? locparts[2] : "";


                    if (parts3[2] != "NULL")
                        user.Age = int.Parse(parts3[2].Trim('"'));
                    else
                        user.Age = -1;

                    bookDetails.Users.Add(user);








                }








            }
        }
    }
}
