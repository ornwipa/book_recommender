using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using recommender.Data;
using recommender.Services;

namespace recommender.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
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
        public static int[][] constructUserJaggedArray()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var context = new ApplicationDbContext(optionBuilder.Options);
            Rating[] ratings = context.Ratings.ToArray();
            // Rating[] ratings = ratingservice.getRatingData();
            // var ratings = TinyCsvParserRating.ReadRatingCsv();            

            int[][] data_matrix = new int[53425][]; // add one more row to spare for new user           
            for (int user_row = 0; user_row < 53425; user_row++)
            {
                data_matrix[user_row] = new int[10000];
            }
            
            for (int m = 0; m < ratings.Length; m++)
            {
                try {
                    data_matrix[ratings[m].user_id-1][ratings[m].book_id-1] = ratings[m].rating_;
                }
                catch (System.IndexOutOfRangeException) {
                    data_matrix[53424][ratings[m].book_id-1] = ratings[m].rating_; // new user
                    continue;
                }
            }
            return data_matrix;
        }

        /// <summary>
        /// From database context, Rating entity, extract ratings by a specific user
        /// </summary>
        /// <param name="user_id">string of user_id</param>
        /// <returns>one-dimensional array of 10000 elements of book ratings by a user</returns>
        public static int[] getRatingByUser(string user_id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var context = new ApplicationDbContext(optionBuilder.Options);
            Rating[] ratings = context.Ratings.Where(x => x.user_id == (Convert.ToInt32(user_id)+1)).ToArray();

            int[] user_ratings = new int[10000];

            for (int m = 0; m < ratings.Length; m++)
            {
                user_ratings[ratings[m].book_id-1] = ratings[m].rating_;
            }
            return user_ratings;
        }
    }
}