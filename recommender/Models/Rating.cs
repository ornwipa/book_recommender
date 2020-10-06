using System;
using recommender.Services;

namespace recommender.Models
{
    public class Rating
    {
        public int book_id { get; set; }
        public int user_id { get; set; }
        
        /// <summary>
        /// rating for each book_id by each user_id
        /// </summary>
        public int rating_ { get; set; }

        /// <summary>
        /// From existing data, construct a user(row)-book(column)-rating(value) relationship
        /// </summary>
        /// <returns>a jagged array of ratings (an array of users' arrays of ratings)</returns>
        public static int[][] constructUserJaggedArray(IRatingService ratingservice)
        {
            // var ratings = TinyCsvParserRating.ReadRatingCsv();
            Rating[] ratings = ratingservice.getRatingData();

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
    }
}