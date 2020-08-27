using System;

namespace recommender.Models
{
    public class User
    {
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

        public double[] userCosineSimilarity(double[][] user_jaggedarray)
        {
            double[] similarity = new double[53424];
            for (int u = 0; u < similarity.Length; u++)
            {
                similarity[u] = VectorOpt.cosineSimilarity(this.rating, user_jaggedarray[u]);
            }
            return similarity;
        }
    } 
}