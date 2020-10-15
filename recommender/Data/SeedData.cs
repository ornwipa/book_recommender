using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using recommender.Models;

namespace recommender.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Books.Any() && context.Ratings.Any())
                {
                    return;
                }
                Book[] book_data = TinyCsvParserBook.ReadBookCsv();
                for (int b = 0; b < book_data.Length; b++)
                {
                    if (book_data[b] != null) 
                    {
                        context.Books.Add(book_data[b]);
                    } 
                }
                Rating[] rating_data = TinyCsvParserRating.ReadRatingCsv();
                context.Ratings.AddRange(rating_data);
                context.SaveChanges();
            }
        }
    }
}