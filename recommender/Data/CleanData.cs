using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using recommender.Models;

namespace recommender.Data
{
    public static class CleanData
    {
        public static void RemoveZeroRating(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var zero_rating = context.Ratings.Where(x => x.rating_ == 0).AsEnumerable();
                context.Ratings.RemoveRange(zero_rating);
                context.SaveChanges();
            }
        }
    }
}