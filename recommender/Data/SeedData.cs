using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using recommender.Models;
using recommender.Services;

namespace recommender.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // BookService bookservice = new BookService();
            // RatingService ratingservice = new RatingService();
            
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                /* if (context.Books.Any() || context.Ratings.Any())
                {
                    return;
                } */
                Book[] book_data = TinyCsvParserBook.ReadBookCsv();
                Rating[] rating_data = TinyCsvParserRating.ReadRatingCsv();
                context.Books.AddRange(book_data);
                context.Ratings.AddRange(rating_data);
                context.SaveChanges();
            }
        }
    }
}