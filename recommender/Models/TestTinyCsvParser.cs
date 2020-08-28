using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace recommender.Models
{
    public class Test
    {
        public static void testCsvParser()
        {
            List<Book> records = TinyCsvParserBook.ReadBookCsv();
            int n_books = records.Count;
            Console.WriteLine("Number of books " + n_books);
            Console.WriteLine("Type of records " + records[0]);
            Console.WriteLine("id " + records[0].id);
            Console.WriteLine("book_id " + records[0].book_id);
            Console.WriteLine("isbn " + records[0].isbn);
            Console.WriteLine("authors " + records[0].authors);
            Console.WriteLine("year " + records[0].year);
            Console.WriteLine("original title " + records[0].original_title);
            Console.WriteLine("title " + records[0].title);
            Console.WriteLine("language code " + records[0].language_code);
            Console.WriteLine("average rating " + records[0].average_rating);
            Console.WriteLine("ratings count " + records[0].ratings_count);
            Console.WriteLine("image URL " + records[0].image_url);

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
    }
}