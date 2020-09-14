using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace recommender.Models
{
    public class User
    {
        /// <summary>
        /// user_id as string input from view home page
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// array of 10k elements represent ratings of 10k books by a user
        /// </summary>
        public int[] rating; // { get; set; }

        /// <summary>
        /// constructor for User class
        /// </summary>
        /* not using these two constructor due to problem with MVC 
        public User()
        {
        }
        public User(string user_id) : this()
        {
            this.user_id = user_id;
            int[][] user_jaggedarray = constructUserJaggedArray();
            this.rating = user_jaggedarray[Convert.ToInt32(this.user_id)];
        }
        */
        
        /// <summary>
        /// For existing user, use this method to set ratings instead of constructor
        /// </summary>
        public void setRatings()
        {
            int[][] user_jaggedarray = User.constructUserJaggedArray();
            this.rating = user_jaggedarray[Convert.ToInt32(this.user_id)];
        }

        /// <summary>
        /// Set ratings for any user (new or existing)
        /// </summary>
        /// <param name="ratings">a 1D array of 10k elements of ratings from 0 to 5</param>
        public void setRatings(int[] ratings)
        {
            this.rating = ratings;
        }

        /// <summary>
        /// Set this User object's rating, the Book object's rating also changes
        /// </summary>
        /// <param name="book">the Book object to which the new rating is set</param>
        /// <param name="rating">new rating to be set</param>
        public void setRating(Book book, int rating)
        {
            this.rating[book.id-1] = rating;
            book.rating = rating;
        }

        /// <summary>
        /// Set this User object's rating, the Book object's rating remains unchanged
        /// </summary>
        /// <param name="col_index">column index in this.rating, equivalent to Book's id-1</param>
        /// <param name="rating">new rating to be set</param>
        public void setRating(int col_index, int rating)
        {
            this.rating[col_index] = rating;
        }

        /// <summary>
        /// From existing data, construct a user(row)-book(column)-rating(value) relationship
        /// </summary>
        /// <returns>a jagged array of ratings, by user</returns>
        public static int[][] constructUserJaggedArray()
        {
            var ratings = TinyCsvParserRating.ReadRatingCsv();

            int[][] data_matrix = new int[53424][]; // n_users is to be replaced later            
            for (int user_row = 0; user_row < 53424; user_row++)
            {
                data_matrix[user_row] = new int[10000]; // initialize inner elements to 0
            }
            
            for (int m = 0; m < ratings.Length; m++)
            {
                data_matrix[ratings[m].user_id-1][ratings[m].book_id-1] = ratings[m].rating_;
            }
            return data_matrix;
        }

        /// <summary>
        /// Get a given user's ratings from existing data
        /// </summary>
        /// <param name="user_jaggedarray">user(row)-book(column)-rating(value)</param>
        /// <param name="user_index">row_id representing the user in the jagged array</param>
        /// <returns>User class with this.rating extracted from existing data</returns>
        public static User accessUser(int[][] user_jaggedarray, int user_index)
        {
            User current_user = new User();
            current_user.user_id = user_index.ToString();
            current_user.rating = user_jaggedarray[user_index];
            int no_book_rated = VectorOpt.CountNonZero(current_user.rating);
            // Console.WriteLine("The user rated {0} books.", no_book_rated);
            return current_user;
        } 

        /// <summary>
        /// Get books that a given user rated
        /// </summary>
        /// <returns>a list of rated books</returns>
        public List<Book> getRatedBook()
        {
            List<Book> rated_book = new List<Book>();
            // this.setRatings(); // User class set ratings, all books for a user

            for (int b = 0; b < 10000; b++) // replace this.rating.Length with 10000
            {
                if (this.rating[b] != 0)
                {
                    Book selected_book = new Book();
                    selected_book = Book.selectBook(b); // book without rating
                    // RatedBook selected_rated_book = new RatedBook(this);
                    // RatedBook selected_rated_book = (RatedBook)selected_book;
                    // selected_book.setRating(this); // Book class set rating
                    // selected_book.setRating(this.rating[b]);
                    if (selected_book != null) // to prevent null reference
                    {
                        selected_book.rating = this.rating[b];
                        rated_book.Add(selected_book);
                    }                                       
                }
            }
            rated_book.Remove(null);
            return rated_book;
        }

        /// <summary>
        /// Get books recommended for a given user
        /// </summary>
        /// <returns>a list of recommended books</returns>
        public List<Book> getRecommendedBook() // combine similarUser() into this method
        {
            List<Book> recommended_book = new List<Book>(); 
            int[][] user_jaggedarray = User.constructUserJaggedArray();
            double similarity;
            int no_similar_users = 0;
            int[] sum_book_rating = new int[10000];
            int sum_rating_cutoff;
            // int no_recommended_book = 0;
            
            for (int u = 0; u < user_jaggedarray.Length; u++)
            {
                similarity = VectorOpt.cosineSimilarity(this.rating, user_jaggedarray[u]);
                if (similarity > 0.1) // arbitary number for the minimum cosine similarity
                {
                    no_similar_users += 1;
                    for (int b = 0; b < 10000; b++)
                    {
                        // sum_book_rating[b] += accessUser(user_jaggedarray, u).rating[b];
                        sum_book_rating[b] = sum_book_rating[b] + user_jaggedarray[u][b];
                    }
                }
            }
            // Console.WriteLine("There are {0} similar users.", no_similar_users-1);                    

            if (this.rating.Sum() > 30) // for users who rated many books
            {
                sum_rating_cutoff = sum_book_rating.Max()/5;
            }
            else  // for users who rated a few books, assuming less than 10 books
            {
                sum_rating_cutoff = sum_book_rating.Sum()/no_similar_users/2;
            }

            for (int b = 0; b < 10000; b++)
            {                
                if (sum_book_rating[b] > sum_rating_cutoff && this.rating[b] == 0)
                {
                    Book selected_book = Book.selectBook(b);
                    if (selected_book != null)
                    {
                        recommended_book.Add(selected_book);
                        // no_recommended_book += 1;
                    }
                }
            }
            recommended_book.Remove(null);
            // Console.WriteLine("{0} books are recommended.", recommended_book.Count());
            // foreach (Book book in recommended_book)
            // {
            //     Console.WriteLine(book.citeBook("unknown style"));
            // }
            return recommended_book;
        }
    } 
}