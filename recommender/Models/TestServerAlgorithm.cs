using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using recommender.Data;
using recommender.Services;

namespace recommender.Models
{
    public class Test
    {
        /// <summary>
        /// Test TinyCsvParser helper library
        /// </summary>
        public static void testCsvParser()
        {
            Book[] records = TinyCsvParserBook.ReadBookCsv();
            int n_books = records.Length;
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

            Rating[] ratings = TinyCsvParserRating.ReadRatingCsv();
            int n_ratings = ratings.Length;
            Console.WriteLine("Number of ratings " + n_ratings);
            Console.WriteLine("First book_id: " + ratings[0].book_id);
            Console.WriteLine("First user_id: " + ratings[0].user_id);
            Console.WriteLine("First rating: " + ratings[0].rating_);
            Console.WriteLine("Last book_id: " + ratings[n_ratings - 1].book_id);
            Console.WriteLine("Last user_id: " + ratings[n_ratings - 1].user_id);
            Console.WriteLine("Last rating: " + ratings[n_ratings - 1].rating_);
        }

        /// <summary>
        /// Test server's recommendation engine
        /// </summary>
        public static void testRecommendationAlgorithm()
        {
            IRatingService ratingService = new RatingService();
            int[][] user_jaggedarray = Rating.constructUserJaggedArray(ratingService);
            // Console.Write("Enter user_id: "); // will be replace with UI
            string user_id = "23"; // Console.ReadLine(); // will be replace with UI
            // User current_user = User.accessUser(user_jaggedarray, Convert.ToInt32(user_id));
            IBookService bookService = new BookService();
            User current_user = new User(bookService, ratingService, user_id);
            List<Book> rated_book = current_user.getRatedBook();
            List<Book> recommended_book = current_user.getRecommendedBook();  
        }
        
        /// <summary>
        /// Test search function
        /// </summary>
        public static void testSearch()
        {
            IBookService bookService = new BookService();
            List<Book> search = Book.searchBook("J.K. Rowling", bookService);
            if (search.Count == 0)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                for (int b = 0; b < search.Count; b++)
                {
                    Console.WriteLine(search[b].ToString());
                }
            }
        }
    }
}