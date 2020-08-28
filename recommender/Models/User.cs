using System;
using System.Collections.Generic;
using System.Linq;

namespace recommender.Models
{
    public class User
    {
        /// <summary>
        /// array of 10k elements represent ratings of 10k books by a user
        /// </summary>
        /// <value></value>
        public double[] rating { set; get; }
        public static double[][] constructUserJaggedArray()
        {
            var ratings = TinyCsvParserRating.ReadRatingCsv();

            double[][] data_matrix = new double[53424][]; // n_users is to be replaced later            
            for (int user_row = 0; user_row < 53424; user_row++)
            {
                data_matrix[user_row] = new double[10000]; // initialize inner elements to 0
            }
            
            for (int m = 0; m < ratings.Count; m++)
            {
                data_matrix[ratings[m].user_id-1][ratings[m].book_id-1] = ratings[m].rating_;
            }
            return data_matrix;
        }

        public static User accessUser(double[][] user_jaggedarray, int user_index)
        {
            User current_user = new User();
            current_user.rating = user_jaggedarray[user_index];
            int no_book_rated = VectorOpt.CountNonZero(current_user.rating);
            // Console.WriteLine("The user rated {0} books.", no_book_rated);
            return current_user;
        } 

        public List<User> similarUser(double[][] user_jaggedarray)
        {
            List<int> similar_user_index = new List<int>();
            List<User> similar_user = new List<User>();

            double[] similarity = new double[53424]; // currently built on existing database
            for (int u = 0; u < similarity.Length; u++)
            {
                similarity[u] = VectorOpt.cosineSimilarity(this.rating, user_jaggedarray[u]);
                if (similarity[u] > 0.1) // arbitary number for the minimum cosine similarity
                {
                    similar_user_index.Add(u);
                    similar_user.Add(accessUser(user_jaggedarray, u));
                }
            }
            // Console.WriteLine("There are {0} similar users.", similar_user_index.Count-1);
            return similar_user;
        }

        public List<Book> getRatedBook()
        {
            List<Book> rated_book = new List<Book>();
            for (int b = 0; b < this.rating.Length; b++)
            {
                if (this.rating[b] != 0)
                {
                    rated_book.Add(Book.selectBook(b));
                }
            }
            return rated_book;
        }

        public List<Book> getRecommendedBook(List<User> similar_user)
        {
            List<Book> recommended_book = new List<Book>();
            
            double[] sum_book_rating = new double[10000];
            double[] avg_book_rating = new double[10000];
            int no_recommended_book = 0;
            for (int b = 0; b < 10000; b++)
            {
                for (int u = 0; u < similar_user.Count; u++)
                {
                    sum_book_rating[b] = sum_book_rating[b] + similar_user[u].rating[b];
                }
                avg_book_rating[b] = sum_book_rating[b]/similar_user.Count;

                if (avg_book_rating[b] > 0.5 && this.rating[b] != 0)
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