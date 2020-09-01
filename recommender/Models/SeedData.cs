using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using recommender.Data;

namespace recommender.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, 
                                        string user_id, double[][] user_jaggedarray)
        {
            User current_user = User.accessUser(user_jaggedarray, Convert.ToInt32(user_id));
            List<Book> rated_book = current_user.getRatedBook();
            List<User> similar_user = current_user.similarUser();
            List<Book> recommended_book = current_user.getRecommendedBook(similar_user);

            using (var context_rated = new BookContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
                {                    
                    foreach (Book book in rated_book)
                    {
                        context_rated.Book.Add(book);
                    }
                    // context_rated.Book.AddRange(rated_book);
                    context_rated.SaveChanges();
                }
            
            using (var context_recommended = new BookContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
                {
                    foreach (Book book in recommended_book)
                    {
                        context_recommended.Book.Add(book);
                    }
                    // context_recommended.Book.AddRange(recommended_book);
                    context_recommended.SaveChanges();
                }
        }
    }
}
