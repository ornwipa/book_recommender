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
        /* not using due to problem with MVC
        public User()
        {
            double[][] user_jaggedarray = constructUserJaggedArray();
            this.rating = user_jaggedarray[Convert.ToInt32(this.user_id)];
        }
        */
        
        public void setRatings() // use this method to set ratings instead of constructor
        {
            int[][] user_jaggedarray = User.constructUserJaggedArray();
            this.rating = user_jaggedarray[Convert.ToInt32(this.user_id)];
        }

        public static int[][] constructUserJaggedArray()
        {
            var ratings = TinyCsvParserRating.ReadRatingCsv();

            int[][] data_matrix = new int[53424][]; // n_users is to be replaced later            
            for (int user_row = 0; user_row < 53424; user_row++)
            {
                data_matrix[user_row] = new int[10000]; // initialize inner elements to 0
            }
            
            for (int m = 0; m < ratings.Count; m++)
            {
                data_matrix[ratings[m].user_id-1][ratings[m].book_id-1] = ratings[m].rating_;
            }
            return data_matrix;
        }

        public static User accessUser(int[][] user_jaggedarray, int user_index)
        {
            User current_user = new User();
            current_user.user_id = user_index.ToString();
            current_user.rating = user_jaggedarray[user_index];
            int no_book_rated = VectorOpt.CountNonZero(current_user.rating);
            // Console.WriteLine("The user rated {0} books.", no_book_rated);
            return current_user;
        } 

        public List<Book> getRatedBook()
        {
            List<Book> rated_book = new List<Book>();
            for (int b = 0; b < 10000; b++) // replace this.rating.Length with 10000
            {
                if (this.rating[b] != 0)
                {
                    rated_book.Add(RatedBook.selectBook(b));
                }
            }
            rated_book.Remove(null);
            return rated_book;
        }

        public List<Book> getRecommendedBook() // combine similarUser() into this method
        {
            List<Book> recommended_book = new List<Book>(); 
            int[][] user_jaggedarray = User.constructUserJaggedArray();
            double similarity;
            int no_similar_users = 0;
            int[] sum_book_rating = new int[10000];
            int no_recommended_book = 0;
            
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

            for (int b = 0; b < 10000; b++)
            {                
                if (sum_book_rating[b] > sum_book_rating.Max()/50 && this.rating[b] == 0)
                {
                    recommended_book.Add(Book.selectBook(b));
                    no_recommended_book += 1;
                }
            }
            // Console.WriteLine("{0} books are recommended.", no_recommended_book);
            // foreach (Book book in recommended_book)
            // {
            //     Console.WriteLine(book.citeBook("unknown style"));
            // }
            return recommended_book;
        }
    } 
}