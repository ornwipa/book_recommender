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
        public static int[][] constructUserJaggedArray(IRatingService ratingservice)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var context = new ApplicationDbContext(optionBuilder.Options);
            Rating[] ratings = context.Ratings.ToArray();
            // Rating[] ratings = ratingservice.getRatingData();
            // var ratings = TinyCsvParserRating.ReadRatingCsv();            

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