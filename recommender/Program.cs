using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using recommender.Models;

namespace recommender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            testCsvParser();

            int[][] user_matrix = constructUserMatrix();

            Console.Write("Enter user_id: "); // will be replace with UI
            string user_row = Console.ReadLine(); // will be replace with UI
            int user_index = Convert.ToInt32(user_row);

            User current_user = accessUser(user_matrix, user_index);
            Console.WriteLine("{0}", current_user.rating[2319]); // non-zero one
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void testCsvParser()
        {
            var records = TinyCsvParserRead.ReadBookCsv();
            int n_books = records.Count;
            Console.WriteLine("Number of books " + n_books);
            Console.WriteLine("Type of records " + records[0]);
            Console.WriteLine("id " + records[0].id);
            Console.WriteLine("book_id " + records[0].book_id);
            Console.WriteLine("isbn " + records[0].isbn);
            Console.WriteLine("authors " + records[0].authors);
            Console.WriteLine("year " + records[0].year);
            Console.WriteLine("title " + records[0].title);
            Console.WriteLine("image_url " + records[0].image_url);

            var ratings = TinyCsvParserRating.ReadRatingCsv();
            int n_ratings = ratings.Count;
            Console.WriteLine("Number of ratings " + n_ratings);
            Console.WriteLine("First book_id: " + ratings[0].book_id);
            Console.WriteLine("First user_id: " + ratings[0].user_id);
            Console.WriteLine("First rating: " + ratings[0].rating_);
            Console.WriteLine("Last book_id: " + ratings[n_ratings - 1].book_id);
            Console.WriteLine("Last user_id: " + ratings[n_ratings - 1].user_id);
            Console.WriteLine("Last rating: " + ratings[n_ratings - 1].rating_);
        }
        public static int[][] constructUserMatrix()
        {
            var ratings = TinyCsvParserRating.ReadRatingCsv();
            // Console.WriteLine(ratings[110896].user_id);
            int[][] data_matrix = new int[53424][]; // n_users, n_books to be replaced
            // Console.WriteLine(data_matrix.Count());
            for (int user_row = 0; user_row < 53424; user_row++) // iterate jagged array
            {
                data_matrix[user_row] = new int[10000]; // initialize inner elements
            }
            // Console.WriteLine(data_matrix[53423][9999]);
            for (int m = 0; m < ratings.Count; m++)
            {
                data_matrix[ratings[m].user_id-1][ratings[m].book_id-1] = ratings[m].rating_;
            }
            return data_matrix;
        }
        public static User accessUser(int[][] user_matrix, int user_index)
        {
            User current_user = new User();
            current_user.rating = user_matrix[user_index];
            int no_book_rated = CountNonZero(current_user.rating);
            Console.WriteLine("The user rated {0} books.", no_book_rated);
            return current_user;
        }        
        public static int CountNonZero<T>(T[] arg) // to be used for any vectors
        {
            int no_elements = 0;
            for (int k = 0; k < arg.Length; k++) 
            {                
                if (Convert.ToInt32(arg[k]) != 0) no_elements++; 
            }
            return no_elements;
        }
    }
}
